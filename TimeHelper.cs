using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class TimeHelper
    {
        public delegate int Delegate_Sequential_Search(List<int> arr, int key);

        public static void GetRunTime(Delegate_Sequential_Search handler, List<int> arr, int key)
        {
            //DateTime beforDT = System.DateTime.Now;
            //var result = handler(arr, key);

            //DateTime afterDT = System.DateTime.Now;
            //TimeSpan ts = afterDT.Subtract(beforDT);
            //Console.WriteLine("DateTime总共花费{0}ms.", ts.TotalMilliseconds);

            Stopwatch s = new Stopwatch();
            s.Start();

            var result = handler(arr, key);

            s.Stop();
            Console.WriteLine("DateTime总共花费{0}ms.", s.ElapsedMilliseconds);
            Console.WriteLine("Sequential_Search:{0} ", result);

        }
    }
}
