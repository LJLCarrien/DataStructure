using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Learn
{
    class People<T> : IEnumerable<T>
    {
        public T[] pers;
        readonly int test;
        public People(T[] ps)
        {
            pers = ps;
            test = 1;
            test = 4;
            test = 5;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(pers);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(pers);
        }


        /// <summary>
        /// 枚举器
        /// </summary>

        public struct Enumerator<T> : IDisposable, IEnumerator<T>
        {
            int position;

            public T[] pers;
            public Enumerator(T[] per)
            {
                this.position = -1;
                this.pers = per;
            }
            public bool MoveNext()
            {
                position++;
                return position < pers.Length;
            }
            public void Reset()
            {
                position = -1;
            }
            public void Dispose()
            {

            }
            public T Current
            {
                get
                {
                    try
                    {
                        return pers[position];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current => Current;
        }
    }
}
