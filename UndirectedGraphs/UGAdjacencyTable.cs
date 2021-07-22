using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.UndirectedGraphs
{
    /// <summary>
    /// 边表结点
    /// </summary>
    class EdgeNode
    {
        /// <summary>
        /// 邻接点下标
        /// </summary>
        public int Adjvex;
        /// <summary>
        /// 权重
        /// </summary>
        public string Weight;
        /// <summary>
        /// 下一个邻接点
        /// </summary>
        public EdgeNode Next;
        public EdgeNode(int adjVex, string w = null, EdgeNode n = null)
        {
            Adjvex = adjVex;
            Weight = w;
            Next = n;
        }
    }

    /// <summary>
    /// 顶点表结点
    /// </summary>
    class VertexNode
    {
        /// <summary>
        /// 下标
        /// </summary>
        public int Index;
        /// <summary>
        /// 顶点信息
        /// </summary>
        public string Data;
        /// <summary>
        /// 边表结点
        /// </summary>
        public EdgeNode FirstEdge;
        public VertexNode(int i, string s, EdgeNode n = null)
        {
            Index = i;
            Data = s;
            FirstEdge = n;
        }
        public void SetEdgeNode(EdgeNode n)
        {
            FirstEdge = n;
        }

        public void PrintSelf()
        {
            Console.WriteLine("data:{0},Index:{1}", Data, Index);

        }
    }
    /// <summary>
    /// 邻接表实现无向图
    /// </summary>
    class UGAdjacencyTable
    {
        /// <summary>
        /// 顶点表
        /// </summary>
        List<VertexNode> vexList;

        /// <summary>
        /// 图中当前的顶点数
        /// </summary>
        int numVertexes;

        /// <summary>
        /// 图中当前的边数
        /// </summary>
        int numEdges;


        public UGAdjacencyTable()
        {
            vexList = new List<VertexNode>();
        }

        /// <summary>
        /// 添加顶点
        /// </summary>
        /// <param name="s"></param>
        public void AddVertex(string s)
        {
            VertexNode v = new VertexNode(vexList.Count, s);
            vexList.Add(v);
            numVertexes++;

            v.PrintSelf();
        }

        /// <summary>
        /// 添加边
        /// </summary>
        /// <param name="v1Index">顶点1下标</param>
        /// <param name="v2Index">顶点2下标</param>
        public void AddEdge(int v1Index, int v2Index)
        {
            if (v1Index >= vexList.Count || v2Index >= vexList.Count)
            {
                Console.WriteLine("[Error] 添加边失败，顶点下标越界");
                return;
            }
            VertexNode v1Node = vexList[v1Index];
            VertexNode v2Node = vexList[v2Index];

            EdgeNode edge1 = new EdgeNode(v1Index);
            EdgeNode edge2 = new EdgeNode(v2Index);
            if (v1Node.FirstEdge == null)
            {
                v1Node.FirstEdge = edge2;
                numEdges++;
            }
            else
            {
                EdgeNode tmpEdgeNode = v1Node.FirstEdge;

                while (tmpEdgeNode.Next != null)
                {
                    tmpEdgeNode = tmpEdgeNode.Next;
                }
                if (tmpEdgeNode.Next == null)
                {
                    tmpEdgeNode.Next = edge2;
                    numEdges++;
                }
            }

            if (v2Node.FirstEdge == null)
            {
                v2Node.FirstEdge = edge1;
                numEdges++;
            }
            else
            {
                EdgeNode tmpEdgeNode = v2Node.FirstEdge;
                while (tmpEdgeNode.Next != null)
                {
                    tmpEdgeNode = tmpEdgeNode.Next;
                }
                if (tmpEdgeNode.Next == null)
                {
                    tmpEdgeNode.Next = edge1;
                    numEdges++;
                }
            }
        }
        /// <summary>
        /// 添加边
        /// </summary>
        /// <param name="startStr">顶点1数据</param>
        /// <param name="endStr">顶点2数据</param>

        public void AddEdge(string startStr, string endStr)
        {
            int startIndex = -1, endIndex = -1;
            GetIndexByStr(startStr, endStr, ref startIndex, ref endIndex);
            if (startIndex != -1 && endIndex != -1)
            {
                AddEdge(startIndex, endIndex);
            }
        }
        /// <summary>
        /// 通过顶点数据，获取顶点下标
        /// </summary>
        /// <param name="startStr"></param>
        /// <param name="endStr"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        private void GetIndexByStr(string startStr, string endStr, ref int startIndex, ref int endIndex)
        {
            int count = vexList.Count;
            for (int i = 0; i < count; i++)
            {
                if (vexList[i].Data == startStr)
                    startIndex = i;
                if (vexList[i].Data == endStr)
                    endIndex = i;
                if (startIndex != -1 && endIndex != -1)
                    break;
            }
        }
        /// <summary>
        /// 移除顶点
        /// </summary>
        public void RemoveVertex(string verStr)
        {
            var verIndex = -1;
            var count = vexList.Count;
            for (int i = 0; i < count; i++)
            {
                if (vexList[i].Data == verStr)
                {
                    verIndex = i;
                    break;
                }
            }
            if (verIndex != -1)
            {
                RemoveVertex(verIndex);
            }
        }

        public void RemoveVertex(int verIndex)
        {
            if (verIndex >= vexList.Count || verIndex < 0)
            {
                Console.WriteLine("[Error] 移除顶点失败，顶点下标越界");
                return;
            }
            var node = vexList[verIndex];
            var tmp = node.FirstEdge;
            while (tmp != null)
            {
                RemoveEdge(node.Index, vexList[tmp.Adjvex].Index);
                tmp = node.FirstEdge;
            }
            //不能真的删除顶点，不然会导致边表结点里存储的下标全部作废的，要么全部边表下标更新一遍，要么就是不存下标，改成指向VertexNode
            //vexList.RemoveAt(verIndex);
            //numVertexes--;
        }

        /// <summary>
        /// 移除边
        /// </summary>
        /// <param name="startStr"></param>
        /// <param name="endStr"></param>
        public void RemoveEdge(string startStr, string endStr)
        {
            int startIndex = -1, endIndex = -1;
            GetIndexByStr(startStr, endStr, ref startIndex, ref endIndex);
            if (startIndex != -1 && endIndex != -1)
            {
                RemoveEdge(startIndex, endIndex);
            }
        }

        public void RemoveEdge(int v1Index, int v2Index)
        {
            RemoveOneEdge(v1Index, v2Index);
            RemoveOneEdge(v2Index, v1Index);
        }
        /// <summary>
        /// 移除单个方向的边
        /// </summary>
        private void RemoveOneEdge(int v1Index, int v2Index)
        {
            if (v1Index >= vexList.Count || v2Index >= vexList.Count)
            {
                Console.WriteLine("[Error] 添加边失败，顶点下标越界");
                return;
            }

            EdgeNode pre = vexList[v1Index].FirstEdge;
            var tmp = vexList[v1Index].FirstEdge;
            while (tmp != null)
            {
                var nodeIndex = tmp.Adjvex;

                if (nodeIndex == v2Index)
                {
                    if (pre == tmp)
                    {
                        vexList[v1Index].FirstEdge = tmp.Next;
                        numEdges--;
                        tmp = null;
                    }
                    else
                    {
                        pre.Next = tmp.Next;
                        numEdges--;
                        tmp = null;
                    }

                }
                if (tmp != null)
                {
                    if (tmp != pre)
                    {
                        pre = tmp;
                    }
                    tmp = tmp.Next;
                }
            }
        }
        /// <summary>
        /// 展示边链表结构
        /// </summary>
        public void ShowAllEdge()
        {
            for (int i = 0; i < vexList.Count; i++)
            {
                Console.WriteLine();
                Console.Write("{0}({1}) ", vexList[i].Data, vexList[i].Index);

                var firstEdge = vexList[i].FirstEdge;
                if (firstEdge != null)
                {
                    Console.Write("-> {0}({1}) ", vexList[firstEdge.Adjvex].Data, vexList[firstEdge.Adjvex].Index);

                    var tmp = vexList[i].FirstEdge.Next;
                    while (tmp != null)
                    {
                        Console.Write("-> {0}({1}) ", vexList[tmp.Adjvex].Data, vexList[tmp.Adjvex].Index);
                        tmp = tmp.Next;
                    }
                }
            }
        }

    }
}
