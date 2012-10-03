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
    internal class EngineContextCast
        : EngineContextNodeBase
    {
        private delegate object CastDelegate(object value);


        public EngineContextCast(
            Type source,
            Type target)
        {
            //this.SourceType = source;
            //this.TargetType = target;

            if (source == typeof(Byte))
            {
                this.Handler =
                    target == typeof(Int16)
                    ? FromByteToInt16
                    : target == typeof(Int32)
                    ? FromByteToInt32
                    : target == typeof(Int64)
                    ? FromByteToInt64
                    : target == typeof(Single)
                    ? FromByteToSingle
                    : target == typeof(Double)
                    ? FromByteToDouble
                    : (CastDelegate)null;
            }
            else if (source == typeof(Int16))
            {
                this.Handler =
                    target == typeof(Byte)
                    ? FromInt16ToByte
                    : target == typeof(Int32)
                    ? FromInt16ToInt32
                    : target == typeof(Int64)
                    ? FromInt16ToInt64
                    : target == typeof(Single)
                    ? FromInt16ToSingle
                    : target == typeof(Double)
                    ? FromInt16ToDouble
                    : (CastDelegate)null;
            }
            else if (source == typeof(Int32))
            {
                this.Handler =
                    target == typeof(Byte)
                    ? FromInt32ToByte
                    : target == typeof(Int16)
                    ? FromInt32ToInt16
                    : target == typeof(Int64)
                    ? FromInt32ToInt64
                    : target == typeof(Single)
                    ? FromInt32ToSingle
                    : target == typeof(Double)
                    ? FromInt32ToDouble
                    : (CastDelegate)null;
            }
            else if (source == typeof(Int64))
            {
                this.Handler =
                    target == typeof(Byte)
                    ? FromInt64ToByte
                    : target == typeof(Int16)
                    ? FromInt64ToInt16
                    : target == typeof(Int32)
                    ? FromInt64ToInt32
                    : target == typeof(Single)
                    ? FromInt64ToSingle
                    : target == typeof(Double)
                    ? FromInt64ToDouble
                    : (CastDelegate)null;
            }
            else if (source == typeof(Single))
            {
                this.Handler =
                    target == typeof(Byte)
                    ? FromSingleToByte
                    : target == typeof(Int16)
                    ? FromSingleToInt16
                    : target == typeof(Int32)
                    ? FromSingleToInt32
                    : target == typeof(Int64)
                    ? FromSingleToInt64
                    : target == typeof(Double)
                    ? FromSingleToDouble
                    : (CastDelegate)null;
            }
            else if (source == typeof(Double))
            {
                this.Handler =
                    target == typeof(Byte)
                    ? FromDoubleToByte
                    : target == typeof(Int16)
                    ? FromDoubleToInt16
                    : target == typeof(Int32)
                    ? FromDoubleToInt32
                    : target == typeof(Int64)
                    ? FromDoubleToInt64
                    : target == typeof(Single)
                    ? FromDoubleToSingle
                    : (CastDelegate)null;
            }
            else
            {
                throw new NotSupportedException();
            }
        }


        //public readonly Type SourceType;
        //public readonly Type TargetType;
        private readonly CastDelegate Handler;

        public EngineContextNodeBase Child;


        protected override object OnRun(EngineSession session)
        {
            object result = this.Child.Run(session);
            return this.Handler(result);
        }


        #region Serialization

        protected override void Deserialize(CodeReader reader)
        {
            this.Child = (EngineContextNodeBase)EngineContextFactory.Create(reader);
        }

        #endregion


        #region Data converters - from Double

        private static object FromDoubleToByte(object value) { return (Byte)(Double)value; }
        private static object FromDoubleToInt16(object value) { return (Int16)(Double)value; }
        private static object FromDoubleToInt32(object value) { return (Int32)(Double)value; }
        private static object FromDoubleToInt64(object value) { return (Int64)(Double)value; }
        private static object FromDoubleToSingle(object value) { return (Single)(Double)value; }

        #endregion


        #region Data converters - from Single

        private static object FromSingleToByte(object value) { return (Byte)(Single)value; }
        private static object FromSingleToInt16(object value) { return (Int16)(Single)value; }
        private static object FromSingleToInt32(object value) { return (Int32)(Single)value; }
        private static object FromSingleToInt64(object value) { return (Int64)(Single)value; }
        private static object FromSingleToDouble(object value) { return (Double)(Single)value; }

        #endregion


        #region Data converters - from Int64

        private static object FromInt64ToByte(object value) { return (Byte)(Int64)value; }
        private static object FromInt64ToInt16(object value) { return (Int16)(Int64)value; }
        private static object FromInt64ToInt32(object value) { return (Int32)(Int64)value; }
        private static object FromInt64ToSingle(object value) { return (Single)(Int64)value; }
        private static object FromInt64ToDouble(object value) { return (Double)(Int64)value; }

        #endregion


        #region Data converters - from Int32

        private static object FromInt32ToByte(object value) { return (Byte)(Int32)value; }
        private static object FromInt32ToInt16(object value) { return (Int16)(Int32)value; }
        private static object FromInt32ToInt64(object value) { return (Int64)(Int32)value; }
        private static object FromInt32ToSingle(object value) { return (Single)(Int32)value; }
        private static object FromInt32ToDouble(object value) { return (Double)(Int32)value; }

        #endregion


        #region Data converters - from Int16

        private static object FromInt16ToByte(object value) { return (Byte)(Int16)value; }
        private static object FromInt16ToInt32(object value) { return (Int32)(Int16)value; }
        private static object FromInt16ToInt64(object value) { return (Int64)(Int16)value; }
        private static object FromInt16ToSingle(object value) { return (Single)(Int16)value; }
        private static object FromInt16ToDouble(object value) { return (Double)(Int16)value; }

        #endregion


        #region Data converters - from Byte

        private static object FromByteToInt16(object value) { return (Int16)(Byte)value; }
        private static object FromByteToInt32(object value) { return (Int32)(Byte)value; }
        private static object FromByteToInt64(object value) { return (Int64)(Byte)value; }
        private static object FromByteToSingle(object value) { return (Single)(Byte)value; }
        private static object FromByteToDouble(object value) { return (Double)(Byte)value; }

        #endregion

    }
}
