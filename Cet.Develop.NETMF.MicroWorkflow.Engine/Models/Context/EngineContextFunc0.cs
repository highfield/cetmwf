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
    public delegate object Func0Delegate(object dc);


    internal class EngineContextFunc0
        : EngineContextFuncBase
    {
        public EngineContextFunc0(Delegate handler)
            : base(handler)
        {
        }


        protected override object OnRun(EngineSession session)
        {
            return ((Func0Delegate)this.Handler)(session.DeviceContext);
        }


        #region Serialization

        protected override void Deserialize(CodeReader reader)
        {
            //do nothing
        }

        #endregion

    }
}
