using System;
using Cet.Develop.MicroWorkflow.Engine;

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
    public static class MicroWorkflowLookup
    {
        public static readonly Delegate[] FunctionTable = new Delegate[]
        {
new Func1Delegate(MicroWorkflowOperators.Not),
new Func2Delegate(MicroWorkflowOperators.AndLogic),
new Func2Delegate(MicroWorkflowOperators.OrLogic),
new Func2Delegate(MicroWorkflowOperators.XorLogic),
new Func2Delegate(MicroWorkflowOperators.AddString),
new Func1Delegate(MicroWorkflowOperators.NegInt32),
new Func2Delegate(MicroWorkflowOperators.AddInt32),
new Func2Delegate(MicroWorkflowOperators.SubInt32),
new Func2Delegate(MicroWorkflowOperators.MulInt32),
new Func2Delegate(MicroWorkflowOperators.DivInt32),
new Func2Delegate(MicroWorkflowOperators.ModInt32),
new Func2Delegate(MicroWorkflowOperators.ShrInt32),
new Func2Delegate(MicroWorkflowOperators.ShlInt32),
new Func2Delegate(MicroWorkflowOperators.EqualInt32),
new Func2Delegate(MicroWorkflowOperators.NotEqualInt32),
new Func2Delegate(MicroWorkflowOperators.LessThanInt32),
new Func2Delegate(MicroWorkflowOperators.LessEqualThanInt32),
new Func2Delegate(MicroWorkflowOperators.GreaterThanInt32),
new Func2Delegate(MicroWorkflowOperators.GreaterEqualThanInt32),
new Func1Delegate(MicroWorkflowOperators.NegInt64),
new Func2Delegate(MicroWorkflowOperators.AddInt64),
new Func2Delegate(MicroWorkflowOperators.SubInt64),
new Func2Delegate(MicroWorkflowOperators.MulInt64),
new Func2Delegate(MicroWorkflowOperators.DivInt64),
new Func2Delegate(MicroWorkflowOperators.ModInt64),
new Func2Delegate(MicroWorkflowOperators.ShrInt64),
new Func2Delegate(MicroWorkflowOperators.ShlInt64),
new Func2Delegate(MicroWorkflowOperators.EqualInt64),
new Func2Delegate(MicroWorkflowOperators.NotEqualInt64),
new Func2Delegate(MicroWorkflowOperators.LessThanInt64),
new Func2Delegate(MicroWorkflowOperators.LessEqualThanInt64),
new Func2Delegate(MicroWorkflowOperators.GreaterThanInt64),
new Func2Delegate(MicroWorkflowOperators.GreaterEqualThanInt64),
new Func1Delegate(MicroWorkflowOperators.NegSingle),
new Func2Delegate(MicroWorkflowOperators.AddSingle),
new Func2Delegate(MicroWorkflowOperators.SubSingle),
new Func2Delegate(MicroWorkflowOperators.MulSingle),
new Func2Delegate(MicroWorkflowOperators.DivSingle),
new Func2Delegate(MicroWorkflowOperators.ModSingle),
new Func2Delegate(MicroWorkflowOperators.EqualSingle),
new Func2Delegate(MicroWorkflowOperators.NotEqualSingle),
new Func2Delegate(MicroWorkflowOperators.LessThanSingle),
new Func2Delegate(MicroWorkflowOperators.LessEqualThanSingle),
new Func2Delegate(MicroWorkflowOperators.GreaterThanSingle),
new Func2Delegate(MicroWorkflowOperators.GreaterEqualThanSingle),
new Func1Delegate(MicroWorkflowOperators.NegDouble),
new Func2Delegate(MicroWorkflowOperators.AddDouble),
new Func2Delegate(MicroWorkflowOperators.SubDouble),
new Func2Delegate(MicroWorkflowOperators.MulDouble),
new Func2Delegate(MicroWorkflowOperators.DivDouble),
new Func2Delegate(MicroWorkflowOperators.ModDouble),
new Func2Delegate(MicroWorkflowOperators.EqualDouble),
new Func2Delegate(MicroWorkflowOperators.NotEqualDouble),
new Func2Delegate(MicroWorkflowOperators.LessThanDouble),
new Func2Delegate(MicroWorkflowOperators.LessEqualThanDouble),
new Func2Delegate(MicroWorkflowOperators.GreaterThanDouble),
new Func2Delegate(MicroWorkflowOperators.GreaterEqualThanDouble),
new Func1Delegate(MicroWorkflowFunctions.WriteOnboardLed),
new Func2Delegate(MicroWorkflowFunctions.WriteOutputPort),
new Func1Delegate(MicroWorkflowFunctions.ReadInputPort),
new Func1Delegate(MicroWorkflowFunctions.ReadAnalogPort),
new Func1Delegate(MicroWorkflowFunctions.Delay),
        };
    }
}