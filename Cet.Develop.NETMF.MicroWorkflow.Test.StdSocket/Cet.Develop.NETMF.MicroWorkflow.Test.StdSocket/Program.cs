using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Net.NetworkInformation;

using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

using Cet.Develop.MicroWorkflow.Engine;
using Cet.Develop.MicroWorkflow.Library.Netduino;

/*
 * Copyright 2012 Mario Vernari (http://cetdevelop.codeplex.com/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Cet.Develop.NETMF.MicroWorkflow.Test
{
    public class Program
    {
        private static MyDC DeviceContext;


        public static void Main()
        {
            //setup the board IP
            NetworkInterface.GetAllNetworkInterfaces()[0]
                .EnableStaticIP("192.168.0.99", "255.255.255.0", "192.168.0.1");

            string localip = NetworkInterface.GetAllNetworkInterfaces()[0]
                .IPAddress;

            Debug.Print("The local IP address of your Netduino Plus is " + localip);

            //create the device context to expose to the engine
            DeviceContext = new MyDC();

            DeviceContext.OnboardLed = new OutputPort(Pins.ONBOARD_LED, false);

            DeviceContext.OutputPorts[0] = new OutputPort(Pins.GPIO_PIN_D0, false);
            DeviceContext.OutputPorts[1] = new OutputPort(Pins.GPIO_PIN_D1, false);
            DeviceContext.OutputPorts[2] = new OutputPort(Pins.GPIO_PIN_D2, false);
            DeviceContext.OutputPorts[3] = new OutputPort(Pins.GPIO_PIN_D3, false);
            DeviceContext.OutputPorts[4] = new OutputPort(Pins.GPIO_PIN_D4, false);
            DeviceContext.OutputPorts[5] = new OutputPort(Pins.GPIO_PIN_D5, false);
            DeviceContext.OutputPorts[6] = new OutputPort(Pins.GPIO_PIN_D6, false);
            DeviceContext.OutputPorts[7] = new OutputPort(Pins.GPIO_PIN_D7, false);

            DeviceContext.InputPorts[0] = new InputPort(Pins.GPIO_PIN_D8, true, Port.ResistorMode.PullUp);
            DeviceContext.InputPorts[1] = new InputPort(Pins.GPIO_PIN_D9, true, Port.ResistorMode.PullUp);
            DeviceContext.InputPorts[2] = new InputPort(Pins.GPIO_PIN_D10, true, Port.ResistorMode.PullUp);
            DeviceContext.InputPorts[3] = new InputPort(Pins.GPIO_PIN_D11, true, Port.ResistorMode.PullUp);
            DeviceContext.InputPorts[4] = new InputPort(Pins.GPIO_PIN_D12, true, Port.ResistorMode.PullUp);
            DeviceContext.InputPorts[5] = new InputPort(Pins.GPIO_PIN_D13, true, Port.ResistorMode.PullUp);

            DeviceContext.AnalogPorts[0] = new AnalogInput(Pins.GPIO_PIN_A0);
            DeviceContext.AnalogPorts[1] = new AnalogInput(Pins.GPIO_PIN_A1);
            DeviceContext.AnalogPorts[2] = new AnalogInput(Pins.GPIO_PIN_A2);
            DeviceContext.AnalogPorts[3] = new AnalogInput(Pins.GPIO_PIN_A3);
            DeviceContext.AnalogPorts[4] = new AnalogInput(Pins.GPIO_PIN_A4);
            DeviceContext.AnalogPorts[5] = new AnalogInput(Pins.GPIO_PIN_A5);

            //start the listening socket
            new Thread(Listen)
                .Start();

            //do whatever

            Thread.Sleep(Timeout.Infinite);
        }


        #region Workflow engine life-cycle

        private static EngineContextRoot _root;
        private static EngineSession _session;
        private static Thread _logicThread;


        /// <summary>
        /// Worker for a single instance of the workflow task
        /// </summary>
        private static void Logic()
        {
            Debug.Print("logic start");

            //create a session holding the data of the task
            _session = new EngineSession(DeviceContext);

            //worst way to catch errors, but...TODO
            try
            {
                //invoke the activities tree against the session
                object result = _root.Run(_session);
            }
            catch (Exception)
            {
                //do nothing
            }
            finally
            {
                _session = null;
            }

            Debug.Print("logic stop");
        }


        /// <summary>
        /// Processs the request incoming from the client
        /// </summary>
        /// <param name="data">The compiled version of the workflow</param>
        private static void ProcessRequest(string data)
        {
            Debug.Print(data);

            //stop current logic, if running
            if (_session != null)
                _session.AbortReq = true;

            if (_logicThread != null &&
                _logicThread.IsAlive)
            {
                _logicThread.Join();
            }

            //decompile the string creating an activities tree
            _root = EngineContextRoot.Create(
                MicroWorkflowLookup.FunctionTable,
                data);

            //start a thread for runnning the task
            _logicThread = new Thread(Logic);
            _logicThread.Start();
        }

        #endregion


        #region Socket listener

        private static void Listen()
        {
            //create a TCP socket
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                //place it as listener on the port 1024
                var ept = new IPEndPoint(IPAddress.Any, 1024);
                socket.Bind(ept);
                socket.Listen(10);

                while (true)
                {
                    //wait for incoming connection
                    using (Socket client = socket.Accept())
                    {
                        int timeout = 100;
                        byte[] incoming = new byte[1024];
                        int count = 0;
                        int expected = -1;

                        while (timeout-- > 0)
                        {
                            var available = client.Available;

                            if (available > 0)
                            {
                                client.Receive(
                                    incoming,
                                    count,
                                    available,
                                    SocketFlags.None);

                                count += available;

                                if (expected < 0 &&
                                    count >= 2)
                                {
                                    expected = incoming[0] + (incoming[1] << 8);
                                }

                                if (expected >= 0 &&
                                    count >= expected)
                                {
                                    //end-of-stream
                                    expected -= 2;
                                    char[] ca = new char[expected];
                                    for (int i = 0; i < expected; i++)
                                    {
                                        ca[i] = (char)incoming[i + 2];
                                    }

                                    ProcessRequest(new string(ca));
                                    break;
                                }
                            }

                            Thread.Sleep(10);
                        }
                    }
                }


            }
        }

        #endregion

    }
}
