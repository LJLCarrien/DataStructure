using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /// <summary>
    /// KMP模式匹配算法
    /// </summary>
    class StringHelper
    {
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
                Console.WriteLine();
                if (front == -1)
                {
                    Console.WriteLine("---backIndex:{0},frontIndex:{1}", back, front);
                }
                else
                {
                    Console.WriteLine("---str[{0}]==str[{1}],{2}=={3}", back, front, str[back], str[front]);
                }
                if (front == -1 || str[back] == str[front])
                {
                    if (front == -1)
                    {
                        Console.WriteLine("[-1] backIndex:{0},frontIndex:{1},nextArr[{2}]={3}", back, front, back, front);
                    }
                    else
                    {
                        Console.WriteLine("[=] backIndex:{0},frontIndex:{1},nextArr[{2}]=={3}", back, front, back, front);
                    }
                    back++;
                    front++;
                    if (!Isbetter)
                    {                   
                        Console.WriteLine("backIndex:{0},frontIndex:{1},nextArr[{2}]={3}", back, front, back, front);
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
                    var tmp = front;
                    var value = nextArr[front];
                    front = nextArr[front];
                    Console.WriteLine("[!=] reset front:{0}->{1}", tmp, value);

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
