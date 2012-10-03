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
        public static void Main()
        {
            //create the device context to expose to the engine
            var DeviceContext = new MyDC();

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


            //a string representing the compiled version of the "basic" workflow
            //this string could be read from any non-volatile medium (e.g. SD, EEProm, etc)
            var data = @"uWRSWKB""1""SSvB000SAl000F059K4""2""F057l000zz";

            //decompile the string creating an activities tree
            var root = EngineContextRoot.Create(
                MicroWorkflowLookup.FunctionTable,
                data);

            //create a session holding the data of the task
            var session = new EngineSession(DeviceContext);

            //invoke the activities tree against the session
            root.Run(session);

            /**
             * NOTE: this example is minimal, with no threading, and no mutation of the running task.
             * That assumes the task will run forever, because there's no code for manage the engine.
             **/
        }

    }
}
