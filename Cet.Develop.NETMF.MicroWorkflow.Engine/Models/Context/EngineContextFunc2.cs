using System;

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
    public delegate object Func2Delegate(object dc, object arg1, object arg2);


    internal class EngineContextFunc2
        : EngineContextFuncBase
    {
        public EngineContextFunc2(Delegate handler)
            : base(handler)
        {
        }


        public EngineContextNodeBase Child1;
        public EngineContextNodeBase Child2;


        protected override object OnRun(EngineSession session)
        {
            return ((Func2Delegate)this.Handler)(
                session.DeviceContext,
                this.Child1.Run(session),
                this.Child2.Run(session)
                );
        }


        #region Serialization

        protected override void Deserialize(CodeReader reader)
        {
            this.Child1 = (EngineContextNodeBase)EngineContextFactory.Create(reader);
            this.Child2 = (EngineContextNodeBase)EngineContextFactory.Create(reader);
        }

        #endregion

    }
}
