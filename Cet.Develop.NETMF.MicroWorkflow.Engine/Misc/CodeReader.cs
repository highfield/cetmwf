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
    public class CodeReader
    {
        internal CodeReader(
            Delegate[] globals,
            string text)
        {
            this.GlobalFuncs = globals ?? new Delegate[0];
            this.Text = text ?? string.Empty;
        }


        internal readonly Delegate[] GlobalFuncs;
        internal readonly string Text;
        internal int Ptr;


        internal char Current
        {
            get { return this.Text[this.Ptr]; }
        }


        internal bool AtEnd
        {
            get { return this.Ptr >= this.Text.Length; }
        }


        internal char Read()
        {
            return this.Text[this.Ptr++];
        }


        internal string TryRead(int count)
        {
            if ((this.Ptr + count) <= this.Text.Length)
            {
                return this.Text.Substring(
                    this.Ptr,
                    count);
            }
            else
            {
                return null;
            }
        }


        internal int ReadIndex()
        {
            var s = this.Text.Substring(
                this.Ptr,
                3);

            this.Ptr += 3;
            return int.Parse(s);
        }

    }
}
