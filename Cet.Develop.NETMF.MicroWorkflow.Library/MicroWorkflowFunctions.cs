using System;
using Cet.Develop.MicroWorkflow.Engine;
using System.Threading;

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
namespace Cet.Develop.MicroWorkflow.Library.Netduino
{
    public static class MicroWorkflowFunctions
    {
        public static object WriteOnboardLed(
            object dc,
            object state)
        {
            ((MyDC)dc).OnboardLed.Write((bool)state);
            return null;
        }

        public static object WriteOutputPort(
            object dc,
            object a,
            object state)
        {
            ((MyDC)dc).OutputPorts[(int)a].Write((bool)state);
            return null;
        }

        
        public static object ReadInputPort(
            object dc,
            object a)
        {
            return ((MyDC)dc).InputPorts[(int)a].Read();
            return null;
        }

        
        public static object ReadAnalogPort(
            object dc,
            object a)
        {
            return ((MyDC)dc).AnalogPorts[(int)a].Read();
            return null;
        }

        public static object Delay(
            object dc,
            object ms)
        {
            Thread.Sleep((int)ms);
            return null;
        }

    }
}
