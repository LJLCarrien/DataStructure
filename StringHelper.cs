using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /// <summary>
    /// 朴素的模式匹配算法
    /// &&
    /// KMP模式匹配算法
    /// </summary>
    class StringHelper
    {
        /// <summary>
        /// 朴素的模式匹配算法
        /// 返回子串T在主串S中第pos个字符后的位置，若不存在返回-1
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static int Index(string S, string T, int pos = 0)
        {
            int i = pos;
            int j = 0;
            //for (int i = pos; i < S.Length && j < T.Length;)
            while (i < S.Length && j < T.Length)
            {
                if (S[i] == T[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    i = i - j + 1;
                    j = 0;
                }
            }
            if (j >= T.Length)
            {
                return i - T.Length;
            }
            return -1;
        }

        public static int[] GetNext(string str, bool Isbetter)
        {
            int len = str.Length;
            int[] nextArr = new int[len];
            nextArr[0] = -1;
            int front = -1;//前缀下标
            int back = 0;//后缀下标
            while (back < len - 1)
            {
                //后缀和前缀相等时
                if (front == -1 || str[back] == str[front])
                {
                    back++;
                    front++;
                    if (!Isbetter)
                    {
                        nextArr[back] = front;
                    }
                    else
                    {
                        //而当前字符和前缀不相等时，
                        if (str[back] != str[front])
                        {
                            //有front个前后缀相同的字符
                            nextArr[back] = front;
                        }
                        else
                        {
                            nextArr[back] = nextArr[front];
                        }
                    }
                }
                else
                {
                    //后缀和前缀不相等时，回到与后缀相等长度的的前缀位置
                    front = nextArr[front];
                }
            }
            for (int i = 0; i < nextArr.Length; i++)
            {
                Console.WriteLine("{0}:{1}", str[i], nextArr[i]);
            }
            return nextArr;
        }


    }
}
