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
    internal static class EngineContextFactory
    {

        internal static IContextSerializer Create(CodeReader reader)
        {
            IContextSerializer instance = null;
            Type t;
            int idx;
            Delegate d;

            switch (reader.Current)
            {
                case 'u':   //root
                    if (reader.TryRead(3) == WorkflowCommonDefs.CompilerNodeRoot)
                    {
                        reader.Ptr += 3;
                        instance = new EngineContextRoot();
                        instance.Deserialize(reader);
                    }
                    break;

                case WorkflowCommonDefs.CompilerTypeVoid:   //nop
                    reader.Ptr++;
                    instance = new EngineContextNop();
                    instance.Deserialize(reader);
                    break;

                case 'v':   //local-var declaration
                    reader.Ptr++;
                    t = GetTypeFromTag(reader.Read());
                    idx = reader.ReadIndex();
                    instance = new EngineVariableTemplate(t, idx.ToString());
                    instance.Deserialize(reader);
                    break;

                case 'F':   //global-func reference
                    reader.Ptr++;
                    idx = reader.ReadIndex();
                    d = reader.GlobalFuncs[idx];
                    instance = CreateFunc(d);
                    instance.Deserialize(reader);
                    break;

                case 'f':   //local-func reference
                    throw new NotSupportedException();

                case 'L':   //global-var reference
                    reader.Ptr++;
                    idx = reader.ReadIndex();
                    instance = new EngineContextGlobalVarReference(idx);
                    instance.Deserialize(reader);
                    break;

                case 'l':   //local-var reference
                    reader.Ptr++;
                    idx = reader.ReadIndex();
                    instance = new EngineContextLocalVarReference(idx);
                    instance.Deserialize(reader);
                    break;

                case 'K':   //constant value
                    reader.Ptr++;
                    t = GetTypeFromTag(reader.Read());
                    instance = new EngineContextConstantValue(t);
                    instance.Deserialize(reader);
                    break;

                case 'C':   //cast
                    reader.Ptr++;
                    t = GetTypeFromTag(reader.Read());
                    instance = new EngineContextCast(
                        GetTypeFromTag(reader.Read()),
                        t);
                    instance.Deserialize(reader);
                    break;

                case 'S':   //statement
                    if (reader.TryRead(2) == WorkflowCommonDefs.CompilerNodeStatementSequence)
                    {
                        reader.Ptr += 2;
                        instance = new EngineContextSequence();
                        instance.Deserialize(reader);
                    }
                    else if (reader.TryRead(2) == WorkflowCommonDefs.CompilerNodeStatementAssign)
                    {
                        reader.Ptr += 2;
                        instance = new EngineContextAssign();
                        instance.Deserialize(reader);
                    }
                    else if (reader.TryRead(2) == WorkflowCommonDefs.CompilerNodeStatementWhile)
                    {
                        reader.Ptr += 2;
                        instance = new EngineContextWhile();
                        instance.Deserialize(reader);
                    }
                    else if (reader.TryRead(2) == WorkflowCommonDefs.CompilerNodeStatementIf)
                    {
                        reader.Ptr += 2;
                        instance = new EngineContextIf();
                        instance.Deserialize(reader);
                    }
                    break;

            }

            if (instance == null)
                throw new NotSupportedException();

            return instance;
        }


        internal static EngineContextFuncBase CreateFunc(Delegate del)
        {
            if (del is Func0Delegate)
                return new EngineContextFunc0(del);
            else if (del is Func1Delegate)
                return new EngineContextFunc1(del);
            else if (del is Func2Delegate)
                return new EngineContextFunc2(del);
            else if (del is Func3Delegate)
                return new EngineContextFunc3(del);
            else if (del is Func4Delegate)
                return new EngineContextFunc4(del);
            else
                throw new NotSupportedException();
        }


        internal static Type GetTypeFromTag(char tag)
        {
            switch (tag)
            {
                case WorkflowCommonDefs.CompilerTypeVoid: return typeof(void);
                case WorkflowCommonDefs.CompilerTypeBoolean: return typeof(Boolean);
                case WorkflowCommonDefs.CompilerTypeByte: return typeof(Byte);
                case WorkflowCommonDefs.CompilerTypeInt16: return typeof(Int16);
                case WorkflowCommonDefs.CompilerTypeInt32: return typeof(Int32);
                case WorkflowCommonDefs.CompilerTypeInt64: return typeof(Int64);
                case WorkflowCommonDefs.CompilerTypeSingle: return typeof(Single);
                case WorkflowCommonDefs.CompilerTypeDouble: return typeof(Double);
                case WorkflowCommonDefs.CompilerTypeString: return typeof(String);
            }

            return null;
        }

    }
}
