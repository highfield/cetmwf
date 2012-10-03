using Cet.Develop.MicroWorkflow.Common;
using System.Collections;

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
    internal class EngineContextSequence
        : EngineContextNodeBase
    {

        public EngineContextNodeBase[] Children;


        protected override object OnRun(EngineSession session)
        {
            foreach (var child in this.Children)
            {
                if (session.AbortReq)
                    break;

                object result = child.Run(session);
            }

            return null;
        }


        #region Serialization

        protected override void Deserialize(CodeReader reader)
        {
            var decls = new ArrayList();
            var children = new ArrayList();

            while (reader.Current != WorkflowCommonDefs.CompilerSegmentEnd)
            {
                IContextSerializer instance = EngineContextFactory.Create(reader);
                var tpl = instance as EngineVariableTemplate;
                var node = instance as EngineContextNodeBase;

                if (tpl != null)
                    decls.Add(tpl);
                else if (node != null)
                    children.Add(node);
            }

            reader.Ptr++;

            if (decls.Count > 0)
            {
                this.Declarations = (EngineVariableTemplate[])decls.ToArray(typeof(EngineVariableTemplate));
            }

            this.Children = (EngineContextNodeBase[])children.ToArray(typeof(EngineContextNodeBase));
        }

        #endregion

    }
}
