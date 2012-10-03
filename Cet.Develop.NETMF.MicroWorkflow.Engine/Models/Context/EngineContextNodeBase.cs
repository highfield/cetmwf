
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
    public abstract class EngineContextNodeBase
        : IContextSerializer
    {
        protected EngineContextNodeBase() { }


        public object Run(EngineSession session)
        {
            int localCount = 0;

            if (this.Declarations != null &&
                (localCount = this.Declarations.Length) > 0)
            {
                for (int i = 0; i < localCount; i++)
                {
                    session.DataStack.Push(this.Declarations[i].CreateSurrogate());
                }
            }

            object result = this.OnRun(session);

            for (int i = 0; i < localCount; i++)
            {
                session.DataStack.Pop();
            }

            return result;
        }

        protected abstract object OnRun(EngineSession session);


        internal EngineVariableTemplate[] Declarations;


        #region Serialization

        protected abstract void Deserialize(CodeReader reader);


        void IContextSerializer.Deserialize(CodeReader reader)
        {
            this.Deserialize(reader);
        }

        #endregion

    }
}
