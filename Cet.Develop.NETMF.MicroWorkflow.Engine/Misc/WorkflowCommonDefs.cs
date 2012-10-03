

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
namespace Cet.Develop.MicroWorkflow.Common
{
    public static class WorkflowCommonDefs
    {
        public const char CompilerTypeVoid = '0';
        public const char CompilerTypeBoolean = 'B';
        public const char CompilerTypeByte = '1';
        public const char CompilerTypeInt16 = '2';
        public const char CompilerTypeInt32 = '4';
        public const char CompilerTypeInt64 = '8';
        public const char CompilerTypeSingle = 'F';
        public const char CompilerTypeDouble = 'D';
        public const char CompilerTypeString = 'S';

        public const char CompilerQuote = '"';
        public const char CompilerSegmentEnd = 'z';

        public const string CompilerNodeRoot = "uWR";
        public const string CompilerNodeDefField = "v";
        public const string CompilerNodeFunctionGlobal = "F";
        public const string CompilerNodeFunctionLocal = "f";
        public const string CompilerNodeLiteralGlobal = "L";
        public const string CompilerNodeLiteralLocal = "l";
        public const string CompilerNodeConstant = "K";
        public const string CompilerNodeCast = "C";

        public const string CompilerNodeStatementSequence = "SS";
        public const string CompilerNodeStatementAssign = "SA";
        public const string CompilerNodeStatementWhile = "SW";
        public const string CompilerNodeStatementIf = "SI";

        //public const char CompilerChildOpen = '{';
        //public const char CompilerChildClose = '}';

    }
}
