using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Learn
{
    class A
    {
        public int q;
        public int w;
        public int e;
    }

    class ReadOnlyTest
    {
        public int x;
        public readonly int y = 25;
        public readonly int z;
        public readonly A a;
        public ReadOnlyTest()
        {
            z = 1;

            a = new A();
            a.q = 1 * x;
            a.w = 10 * y;
            a.e = 100 * z;
        }

        public ReadOnlyTest(int x1, int y1, int z1)
        {
            x = x1;
            y = y1;
            z = z1;

            a = new A();
            a.q = 1 * x1;
            a.w = 10 * y1;
            a.e = 100 * z1;
        }

    }
}
