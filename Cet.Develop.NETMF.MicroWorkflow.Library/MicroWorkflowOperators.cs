using System;
using Cet.Develop.MicroWorkflow.Engine;

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
namespace Cet.Develop.MicroWorkflow.Library.Netduino
{
    public static class MicroWorkflowOperators
    {
        
        
        public static object Not(
            object dc,
            object a)
        {
            return !(Boolean)a;
        }


        
        
        public static object AndLogic(
            object dc,
            object a,
            object b)
        {
            return (Boolean)a && (Boolean)b;
        }


        
        
        public static object OrLogic(
            object dc,
            object a,
            object b)
        {
            return (Boolean)a || (Boolean)b;
        }


        
        
        public static object XorLogic(
            object dc,
            object a,
            object b)
        {
            return (Boolean)a ^ (Boolean)b;
        }


        
        
        public static object AddString(
            object dc,
            object a,
            object b)
        {
            return (String)a + (String)b;
        }

        
        
        public static object NegInt32(
            object dc,
            object a)
        {
            return -(System.Int32)a;
        }


        
        
        public static object AddInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a + (System.Int32)b;
        }


        
        
        public static object SubInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a - (System.Int32)b;
        }


        
        
        public static object MulInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a * (System.Int32)b;
        }


        
        
        public static object DivInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a / (System.Int32)b;
        }


        
        
        public static object ModInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a % (System.Int32)b;
        }

        
        
        public static object ShrInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a >> (Int32)b;
        }


        
        
        public static object ShlInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a << (Int32)b;
        }


        
        
        public static object EqualInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a == (System.Int32)b;
        }


        
        
        public static object NotEqualInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a != (System.Int32)b;
        }


        
        
        public static object LessThanInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a < (System.Int32)b;
        }


        
        
        public static object LessEqualThanInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a <= (System.Int32)b;
        }


        
        
        public static object GreaterThanInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a > (System.Int32)b;
        }


        
        
        public static object GreaterEqualThanInt32(
            object dc,
            object a,
            object b)
        {
            return (System.Int32)a >= (System.Int32)b;
        }

        
        
        public static object NegInt64(
            object dc,
            object a)
        {
            return -(System.Int64)a;
        }


        
        
        public static object AddInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a + (System.Int64)b;
        }


        
        
        public static object SubInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a - (System.Int64)b;
        }


        
        
        public static object MulInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a * (System.Int64)b;
        }


        
        
        public static object DivInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a / (System.Int64)b;
        }


        
        
        public static object ModInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a % (System.Int64)b;
        }

        
        
        public static object ShrInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a >> (Int32)b;
        }


        
        
        public static object ShlInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a << (Int32)b;
        }


        
        
        public static object EqualInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a == (System.Int64)b;
        }


        
        
        public static object NotEqualInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a != (System.Int64)b;
        }


        
        
        public static object LessThanInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a < (System.Int64)b;
        }


        
        
        public static object LessEqualThanInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a <= (System.Int64)b;
        }


        
        
        public static object GreaterThanInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a > (System.Int64)b;
        }


        
        
        public static object GreaterEqualThanInt64(
            object dc,
            object a,
            object b)
        {
            return (System.Int64)a >= (System.Int64)b;
        }

        
        
        public static object NegSingle(
            object dc,
            object a)
        {
            return -(System.Single)a;
        }


        
        
        public static object AddSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a + (System.Single)b;
        }


        
        
        public static object SubSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a - (System.Single)b;
        }


        
        
        public static object MulSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a * (System.Single)b;
        }


        
        
        public static object DivSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a / (System.Single)b;
        }


        
        
        public static object ModSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a % (System.Single)b;
        }


        
        
        public static object EqualSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a == (System.Single)b;
        }


        
        
        public static object NotEqualSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a != (System.Single)b;
        }


        
        
        public static object LessThanSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a < (System.Single)b;
        }


        
        
        public static object LessEqualThanSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a <= (System.Single)b;
        }


        
        
        public static object GreaterThanSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a > (System.Single)b;
        }


        
        
        public static object GreaterEqualThanSingle(
            object dc,
            object a,
            object b)
        {
            return (System.Single)a >= (System.Single)b;
        }

        
        
        public static object NegDouble(
            object dc,
            object a)
        {
            return -(System.Double)a;
        }


        
        
        public static object AddDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a + (System.Double)b;
        }


        
        
        public static object SubDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a - (System.Double)b;
        }


        
        
        public static object MulDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a * (System.Double)b;
        }


        
        
        public static object DivDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a / (System.Double)b;
        }


        
        
        public static object ModDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a % (System.Double)b;
        }


        
        
        public static object EqualDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a == (System.Double)b;
        }


        
        
        public static object NotEqualDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a != (System.Double)b;
        }


        
        
        public static object LessThanDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a < (System.Double)b;
        }


        
        
        public static object LessEqualThanDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a <= (System.Double)b;
        }


        
        
        public static object GreaterThanDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a > (System.Double)b;
        }


        
        
        public static object GreaterEqualThanDouble(
            object dc,
            object a,
            object b)
        {
            return (System.Double)a >= (System.Double)b;
        }

    }
}
