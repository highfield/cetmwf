
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
    internal class EngineContextIf
        : EngineContextNodeBase
    {

        public EngineContextNodeBase Condition;
        public EngineContextNodeBase BodyThen;
        public EngineContextNodeBase BodyElse;


        protected override object OnRun(EngineSession session)
        {
            if ((bool)this.Condition.Run(session))
            {
                return this.BodyThen.Run(session);
            }
            else
            {
                return this.BodyElse.Run(session);
            }
        }


        #region Serialization

        protected override void Deserialize(CodeReader reader)
        {
            this.Condition = (EngineContextNodeBase)EngineContextFactory.Create(reader);
            this.BodyThen = (EngineContextNodeBase)EngineContextFactory.Create(reader);
            this.BodyElse = (EngineContextNodeBase)EngineContextFactory.Create(reader);
        }

        #endregion

    }
}
