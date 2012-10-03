using System;
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
    public sealed class EngineContextRoot
        : EngineContextNodeBase
    {

        internal EngineContextNodeBase Child;


        protected override object OnRun(EngineSession session)
        {
            if (this.Child != null)
                return this.Child.Run(session);
            else
                return null;
        }


        #region Serialization

        protected override void Deserialize(CodeReader reader)
        {
            var decls = new ArrayList();

            while (reader.Current != WorkflowCommonDefs.CompilerSegmentEnd)
            {
                IContextSerializer instance = EngineContextFactory.Create(reader);
                var tpl = instance as EngineVariableTemplate;
                var node = instance as EngineContextNodeBase;

                if (tpl != null)
                    decls.Add(tpl);
                else if (node != null)
                    this.Child = node;
            }

            if (decls.Count > 0)
            {
                this.Declarations = (EngineVariableTemplate[])decls.ToArray(typeof(EngineVariableTemplate));
            }
        }

        #endregion


        public static EngineContextRoot Create(
            Delegate[] globals,
            string text)
        {
            var reader = new CodeReader(
                globals,
                text);

            return EngineContextFactory.Create(reader) as EngineContextRoot;
        }

    }
}
