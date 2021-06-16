using DataStructure.UndirectedGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            //栈的应用 - 计算四则表达式
            //var p1 = ExpressionsHelper.GetPostfixExpression("9+(3-1)*3+10/2");
            //var v1 = ExpressionsHelper.GetPostfixExpressionResult(p1);
            //Console.WriteLine();
            //var p2 = ExpressionsHelper.GetPostfixExpression("1+2*3+(4*5+6)*7");
            //var v2 = ExpressionsHelper.GetPostfixExpressionResult(p2);
            //Console.WriteLine();

            //KMP模式匹配算法
            //StringHelper.GetNext("ABCDABD",false);
            //StringHelper.GetNext("abab",false);

            //无向图的邻接矩阵
            UGAdjacencyMatrix graph = new UGAdjacencyMatrix(9);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddVertex("H");
            graph.AddVertex("I");

            graph.AddEdge("A", "B");
            graph.AddEdge("A", "F");
            graph.AddEdge("B", "C");
            graph.AddEdge("B", "I");
            graph.AddEdge("B", "G");
            graph.AddEdge("C", "I");
            graph.AddEdge("C", "D");
            graph.AddEdge("D", "I");
            graph.AddEdge("D", "G");
            graph.AddEdge("D", "H");
            graph.AddEdge("D", "E");
            graph.AddEdge("E", "H");
            graph.AddEdge("E", "F");
            graph.AddEdge("F", "G");
            graph.AddEdge("G", "H");

            Console.WriteLine("------深度优先遍历-----");
            graph.Depth_First_Search();
            Console.WriteLine("递归-深度优先");
            graph.DFSTraverse();

            Console.WriteLine("------广度优先遍历-----");
            graph.Breadth_First_Search();
            Console.WriteLine("递归-广度优先");
            graph.BFSTraverse();
        }
    }
}
