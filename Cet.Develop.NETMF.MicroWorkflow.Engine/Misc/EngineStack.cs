using System;
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
    internal sealed class EngineStack
        : IEnumerable
    {
        private const int BlockSize = 10;

        private EngineVariableSurrogate[] _collection;

        public int Depth { get; private set; }


        public EngineVariableSurrogate this[int index]
        {
            get
            {
                if (index <= 0 ||
                    index >= this.Depth)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                return this._collection[index];
            }
        }


        public void Push(EngineVariableSurrogate item)
        {
            if (this._collection == null ||
                this._collection.Length >= this.Depth)
            {
                var temp = new EngineVariableSurrogate[this.Depth + BlockSize];

                for (int i = 0; i < this.Depth; i++)
                {
                    temp[i] = this._collection[i];
                }

                this._collection = temp;
            }

            this._collection[this.Depth] = item;
            this.Depth++;
        }


        public EngineVariableSurrogate Pop()
        {
            this.Depth--;
            return this._collection[this.Depth];
        }


        public EngineVariableSurrogate Peek()
        {
            return this._collection[this.Depth - 1];
        }


        public EngineVariableSurrogate GetRelative(int offset)
        {
            return this._collection[this.Depth - 1 - offset];
        }


        public IEnumerator GetEnumerator()
        {
            return this._collection.GetEnumerator();
        }

    }
}
