using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Graphs
{
    class Vertex
    {
        public string Data;
        public int Index;
        public bool isVisited;
        public Vertex(string s, int i)
        {
            Data = s;
            Index = i;
        }
        public void PrintSelf()
        {
            Console.WriteLine("data:{0},Index:{1}", Data, Index);
        }
    }
}
