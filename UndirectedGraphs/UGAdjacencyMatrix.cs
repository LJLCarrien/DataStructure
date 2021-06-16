using DataStructure.Graphs;
using System.Collections.Generic;
using System;
namespace DataStructure.UndirectedGraphs
{
    /// <summary>
    /// 邻接矩阵实现无向图
    /// </summary>
    class UGAdjacencyMatrix
    {

        /// <summary>
        /// 顶点表
        /// </summary>
        List<Vertex> vexList;

        /// <summary>
        /// 边表(二维数组）
        /// </summary>
        int[,] arcArr;

        /// <summary>
        /// 图中当前的顶点数
        /// </summary>
        int numVertexes;

        /// <summary>
        /// 图中当前的边数
        /// </summary>
        int numEdges;

        public UGAdjacencyMatrix(int maxVerNum)
        {
            vexList = new List<Vertex>(maxVerNum);
            arcArr = new int[maxVerNum, maxVerNum];
            numVertexes = 0;
            numEdges = 0;

            for (int i = 0; i < maxVerNum; i++)
            {
                for (int j = 0; j < maxVerNum; j++)
                {
                    arcArr[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// 添加顶点
        /// </summary>
        /// <param name="s"></param>
        public void AddVertex(string s)
        {
            Vertex v = new Vertex(s, vexList.Count);
            vexList.Add(v);
            numVertexes++;

            v.PrintSelf();
        }

        /// <summary>
        /// 添加边
        /// </summary>
        /// <param name="v1Index"></param>
        /// <param name="v2Index"></param>
        public void AddEdge(int v1Index, int v2Index)
        {
            //无向图的边数组是对称矩阵
            arcArr[v1Index, v2Index] = 1;
            arcArr[v2Index, v1Index] = 1;
            numEdges++;
        }
        public void AddEdge(string startStr, string endStr)
        {
            int startIndex = -1, endIndex = -1, count = vexList.Count;
            for (int i = 0; i < count; i++)
            {
                if (vexList[i].Data == startStr)
                    startIndex = i;
                if (vexList[i].Data == endStr)
                    endIndex = i;
            }
            if (startIndex != -1 && endIndex != -1)
            {
                AddEdge(startIndex, endIndex);

            }
        }

        /// <summary>
        /// 从邻接矩阵查找给定点第一个相邻且未被访问过的点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private int getUnVisitedVert(int v)
        {
            for (int j = 0; j < numVertexes; j++)
            {
                if (arcArr[v, j] == 1 && !vexList[j].isVisited)
                {
                    return j;
                }
            }
            return -1;
        }


        /// <summary>
        /// 深度优先遍历-栈实现
        /// </summary>
        public void Depth_First_Search()
        {
            //重置
            int count = vexList.Count;
            for (int i = 0; i < count; i++)
            {
                vexList[i].isVisited = false;
            }
            int index, currentIndex;
            //路径栈
            Stack<int> tmpStack = new Stack<int>();

            vexList[0].isVisited = true;
            Console.WriteLine(vexList[0].Data);
            tmpStack.Push(0);


            while (tmpStack.Count > 0)
            {
                index = -1;
                currentIndex = tmpStack.Peek();
                for (int j = 0; j < count; j++)
                {
                    //从邻接矩阵查找给定点【第一个】相邻且未被访问过的点
                    if (arcArr[currentIndex, j] == 1 && !vexList[j].isVisited)
                    {
                        //一旦找到就跳出
                        index = j;
                        break;
                    }
                }
                //全部都访问过 或者 没有相邻的结点
                if (index == -1)
                {
                    //没有回溯价值，所以出栈
                    tmpStack.Pop();
                }
                else
                {
                    vexList[index].isVisited = true;
                    Console.WriteLine(vexList[index].Data);
                    tmpStack.Push(index);
                }
            }
        }

        private void DFS(int i)
        {
            vexList[i].isVisited = true;
            Console.WriteLine(vexList[i].Data);

            //Console.WriteLine("start:{0}", vexList[i].Data);
            int count = vexList.Count;
            for (int j = 0; j < count; j++)
            {
                if (arcArr[i, j] == 1 && !vexList[j].isVisited)
                {
                    DFS(j);
                }
            }
            //Console.WriteLine("end:{0}", vexList[i].Data);

        }

        /// <summary>
        /// 深度优先遍历-递归实现
        /// </summary>
        public void DFSTraverse()
        {
            //重置
            int count = vexList.Count;

            for (int i = 0; i < count; i++)
            {
                vexList[i].isVisited = false;
            }

            //因为考虑到非连通图的情况，所以需要for循环
            for (int j = 0; j < count; j++)
            {
                if (!vexList[j].isVisited)
                {
                    DFS(j);
                }
            }
        }

        /// <summary>
        /// 广度优先遍历-队列实现
        /// </summary>
        public void Breadth_First_Search()
        {
            int count = vexList.Count;
            for (int i = 0; i < count; i++)
            {
                vexList[i].isVisited = false;
            }

            Queue<int> tmpQueue = new Queue<int>();
            for (int i = 0; i < count; i++)
            {
                if (!vexList[i].isVisited)
                {
                    vexList[i].isVisited = true;
                    Console.WriteLine(vexList[0].Data);
                    tmpQueue.Enqueue(i);

                    while (tmpQueue.Count > 0)
                    {
                        int index = tmpQueue.Dequeue();
                        for (int j = 0; j < count; j++)
                        {
                            //从邻接矩阵查找给定点【所有】相邻且未被访问过的点
                            if (arcArr[index, j] == 1 && !vexList[j].isVisited)
                            {
                                vexList[j].isVisited = true;
                                Console.WriteLine(vexList[j].Data);
                                tmpQueue.Enqueue(j);
                            }
                        }
                    }
                }
            }
        }

        private void BFS(params int[] array)
        {
            List<int> tmp = new List<int>();
            foreach (var i in array)
            {
                if (!vexList[i].isVisited)
                {
                    vexList[i].isVisited = true;
                    Console.WriteLine(vexList[i].Data);
                }

                int count = vexList.Count;
                for (int j = 0; j < count; j++)
                {
                    if (arcArr[i, j] == 1 && !vexList[j].isVisited)
                    {
                        tmp.Add(j);
                    }
                }
            }
            if (tmp.Count > 0)
                BFS(tmp.ToArray());
        }

        /// <summary>
        /// 广度优先遍历-递归实现
        /// </summary>
        public void BFSTraverse()
        {
            //重置
            int count = vexList.Count;

            for (int i = 0; i < count; i++)
            {
                vexList[i].isVisited = false;
            }
            //因为考虑到非连通图的情况，所以需要for循环
            for (int j = 0; j < count; j++)
            {
                if (!vexList[j].isVisited)
                {
                    BFS(j);
                }
            }
        }
    }
}
