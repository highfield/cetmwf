
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
    internal class EngineContextAssign
        : EngineContextNodeBase
    {

        public EngineContextLocalVarReference TargetField;
        public EngineContextNodeBase SourceValue;


        protected override object OnRun(EngineSession session)
        {
            EngineVariableSurrogate vs = session
                .DataStack
                .GetRelative(this.TargetField.StackIndex);

            vs.Value = this
                .SourceValue
                .Run(session);

            return vs.Value;
        }


        #region Serialization

        protected override void Deserialize(CodeReader reader)
        {
            this.TargetField = (EngineContextLocalVarReference)EngineContextFactory.Create(reader);
            this.SourceValue = (EngineContextNodeBase)EngineContextFactory.Create(reader);
        }

        #endregion

    }
}
