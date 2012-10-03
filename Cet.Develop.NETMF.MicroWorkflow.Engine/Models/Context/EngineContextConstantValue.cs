using System;
using Cet.Develop.MicroWorkflow.Common;

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
namespace Cet.Develop.MicroWorkflow.Engine
{
    internal class EngineContextConstantValue
        : EngineContextNodeBase
    {
        public EngineContextConstantValue(Type type)
        {
            this.Type = type;
        }


        public readonly Type Type;
        public object Value;


        protected override object OnRun(EngineSession session)
        {
            return this.Value;
        }


        #region Serialization

        protected override void Deserialize(CodeReader reader)
        {
            if (reader.Read() != WorkflowCommonDefs.CompilerQuote)
                throw new Exception();

            var sb = new char[64];  //TEMP (StringBuilder surrogate)
            var sbix = 0;
            char ch;
            while ((ch = reader.Read()) != WorkflowCommonDefs.CompilerQuote)
                sb[sbix++] = ch;

            var raw = new string(sb, 0, sbix);
            if (this.Type == typeof(Boolean))
            {
                this.Value = int.Parse(raw) != 0;
            }
            else if (this.Type == typeof(Int16))
            {
                this.Value = Int16.Parse(raw);
            }
            else if (this.Type == typeof(Int32))
            {
                this.Value = Int32.Parse(raw);
            }
            else if (this.Type == typeof(Int64))
            {
                this.Value = Int64.Parse(raw);
            }
            else if (this.Type == typeof(Single))
            {
                this.Value = (Single)Double.Parse(raw); //TEMP (Single.Parse missing)
            }
            else if (this.Type == typeof(Double))
            {
                this.Value = Double.Parse(raw);
            }
            else if (this.Type == typeof(String))
            {
                this.Value = raw;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        #endregion

    }
}
