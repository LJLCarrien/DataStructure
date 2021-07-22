using DataStructure.Learn;
using DataStructure.UndirectedGraphs;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Program
    {
      
        static void Main(string[] args)
        {
            //DateTime dtNow = DateTime.Now;
            //int days = DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            //Console.WriteLine(days);

            //VersionTest();

            //StructTest();

            //ReadOnlyTest();

            //varNumberTest();


            DataStructTest();

            //CharTest();

            //EnumeratorTest();

            //EnumHelper.TransferTest();
            //EnumHelper.AttributeTest();

            //ClassTest();

            //PatternMatchTest();

            //GCTest();

            //FormatTest();

            //StringBuilderTest();

            //DelegateTest();


        }
        static void VersionTest()
        {
            //.net 版本 4.8
            Console.WriteLine(RuntimeInformation.FrameworkDescription);
        }

        #region 结构体
        public class A
        {
            public int a;
        }
        public struct MyStructTest
        {
            public int a;//实例字段
            public string Bar { get; set; }//实例属性

            public A z;

            public static int b = 1; //静态字段
            public static readonly int c = 2;
            public const int k = 3;//常量
            public static string staticBar { get; set; } = "bar";//静态属性



        }

        public struct MyStruct
        {
            public int Number;
            private List<string> tags;


            public MyStruct(int n)
            {
                Number = n;
                tags = new List<string>();
            }

            public void AddTag(string tag) => tags.Add(tag);

            public override string ToString() => $"{Number} [{string.Join(", ", tags)}]";
        }

        static void StructTest()
        {
            MyStructTest t1;
            t1.z = new A();
            Console.WriteLine(t1.z.a);
            //var n1 = new MyStruct(0);
            //n1.AddTag("A");
            //Console.WriteLine(n1);  // output: 0 [A]

            //var n2 = n1;
            //n2.Number = 7;
            //n2.AddTag("B");

            //Console.WriteLine(n1);  // output: 0 [A, B]
            //Console.WriteLine(n2);  // output: 7 [A, B]
        }
        #endregion


        #region readonly
        static void ReadOnlyTest()
        {
            ReadOnlyTest t = new ReadOnlyTest(1, 2, 3);
            Console.WriteLine($"t: x={t.x},y={t.y},z={t.z}");

            ReadOnlyTest t1 = new ReadOnlyTest();
            t1.x = 5;
            Console.WriteLine($"t1: x={t1.x},y={t1.y},z={t1.z}");

            t1.a.q = 10;
            t1.a.w = 20;
            t1.a.e = 30;
            //t1.a = new A(); 错误
            //t1.y = 2;错误
            Console.WriteLine($"t1.a: q={t1.a.q},w={t1.a.w},e={t1.a.e}");
        }
        #endregion

        #region 变量

        static int sInt = 200;
        int mInt { get { return 300; } }
        static void varNumberTest()
        {
            int sInt = 30;
            Console.WriteLine("局部变量:{0}", sInt);
            Console.WriteLine("静态变量:{0}", Program.sInt);

            int mInt = 40;
            Console.WriteLine("局部变量:{0}", mInt);
            var p = new Program();
            Console.WriteLine("实例字段:{0}", p.mInt);
        }

        #endregion

        #region 委托
        delegate string GetString();
        delegate void PrintString();
        static void DelegateTest()
        {
            int x = 40;
            GetString firstStringMethod = new GetString(x.ToString);
            Console.WriteLine(firstStringMethod());

            PrintString a = PrintIntString;
            a();

            a = PrintFloatString;
            a();
        }

        static void PrintIntString()
        {
            int y = 50;
            Console.WriteLine(y.ToString());
        }
        static void PrintFloatString()
        {
            float y = 60.0f;
            Console.WriteLine(y.ToString());
        }
        #endregion

        #region string format
        static void FormatTest()
        {
            Console.WriteLine("{0:C0}");

            Console.WriteLine("{0:F0}", 1234);
            Console.WriteLine("{0:F1}", 1234);
            Console.WriteLine("{0:F2}", 1234);

            Console.WriteLine("{0:N0}", 1234);
            Console.WriteLine("{0:N1}", 1234);
            Console.WriteLine("{0:N2}", 1234);
        }
        #endregion

        #region StringBuilder
        static void StringBuilderTest()
        {
            //string str = "111";
            //str = str.ToUpper();
            //Console.WriteLine(str);

            //StringBuilder strb4 = new StringBuilder("012345", 2, 3, 4);
            //strb4.Append("6");
            //Console.WriteLine(strb4);

            //strb4.Remove(0, 1);
            //Console.WriteLine(strb4);

            //strb4.Replace("6", "5");
            //Console.WriteLine(strb4);


            //StringBuilder sb = new StringBuilder();
            //ShowStrBInfo(sb);
            //Console.WriteLine();

            //StringBuilder sbcapcity = new StringBuilder(10);
            //ShowStrBInfo(sbcapcity);
            //Console.WriteLine();

            //StringBuilder strb = new StringBuilder("0123456789");
            //ShowStrBInfo(strb);
            //strb.Append("123456");
            //ShowStrBInfo(strb);
            //strb.Append("7");
            //ShowStrBInfo(strb);
            //Console.WriteLine();

            //StringBuilder strb1 = new StringBuilder("01234567891234567");
            //ShowStrBInfo(strb1);
            //strb1.Append("0");
            //ShowStrBInfo(strb1);
            //strb1.Append("1234567891234567");
            //ShowStrBInfo(strb1);
            //strb1.Append("0");
            //ShowStrBInfo(strb1);
            //Console.WriteLine();

            //StringBuilder strb2 = new StringBuilder("10",4);
            //ShowStrBInfo(strb2);
            //strb2.Append("56");
            //ShowStrBInfo(strb2);

            //StringBuilder strb3 = new StringBuilder(null);
            //ShowStrBInfo(strb3);
            //Console.WriteLine();

            //StringBuilder strb4 = new StringBuilder("012345",2,3,4);
            //Console.WriteLine(strb4);
            //ShowStrBInfo(strb4);


            //strb.Append("This is a sentence.");
            //ShowStrBInfo(strb);
            //for (int i = 0; i < 10; i++)
            //{
            //    strb.Append("This is an additional sentence.");
            //    ShowStrBInfo(strb);
            //}
        }
        private static void ShowStrBInfo(StringBuilder sb)
        {
            foreach (var prop in sb.GetType().GetProperties())
            {
                if (prop.GetIndexParameters().Length == 0)
                    Console.Write("{0}: {1:N2}    ", prop.Name, prop.GetValue(sb));
            }
            Console.WriteLine();
        }
        #endregion


        #region GC
        static void GCTest()
        {
            Program myGCCol = new Program();
            Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);

            myGCCol.MakeSomeGarbage();
            Console.WriteLine("Generation:{0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory:{0}", GC.GetTotalMemory(false));

            GC.Collect(0);

            Console.WriteLine("Generation:{0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory:{0}", GC.GetTotalMemory(false));

            GC.Collect(2);

            Console.WriteLine("Generation:{0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory:{0}", GC.GetTotalMemory(false));

            Console.Read();
        }
        private const long maxGarbage = 1000;
        void MakeSomeGarbage()
        {
            Version vt;
            for (int i = 0; i < maxGarbage; i++)
            {
                vt = new Version();
            }
        }
        #endregion

        #region  模式匹配
        /// <summary>
        /// 模式
        /// </summary>
        static void PatternMatchTest()
        {
            object obj = "hi";
            if (obj is string str)//声明模式，匹配时，转换后的结果赋值给临时变量str
            {
                Console.WriteLine(str);
            }

            Console.WriteLine(getNum(TimeOfDay.Afternoon));
            Console.WriteLine(getNum2(TimeOfDay.Afternoon));

        }

        static int getNum(TimeOfDay? timeOfDay) => timeOfDay switch
        {
            TimeOfDay.Morning => 9,
            TimeOfDay.Afternoon => 15,
            TimeOfDay.Evening => 18,
            _ => 24,
        };

        static int getNum2(TimeOfDay timeOfDay)
        {
            int result = 24;
            switch (timeOfDay)
            {
                case TimeOfDay.Morning:
                    result = 9;
                    break;
                case TimeOfDay.Afternoon:
                    result = 15;
                    break;
                case TimeOfDay.Evening:
                    result = 18;
                    break;
                default:
                    break;
            }
            return result;
        }
        #endregion

        #region 类
        static void ClassTest()
        {
            //Boy boy = new Boy("男", "孩");

            //if (boy is Person)
            //{
            //    //派生类转基类，隐式转换
            //    Person person = boy;
            //    person.ToString();
            //}

            ////模式匹配
            //if (boy is Person p)
            //{
            //    p.ToString();
            //}

            //Girl girl = new Girl("女", "孩");
            //var per = girl as Person;
            //if (per != null)
            //{
            //    per.ToString();
            //}

            ////显式转换
            //Boy boy1 = new Boy("原本男", "孩");
            //Girl girl2 = new Girl("原本女", "孩");

            //Girl newBoy = (Girl)boy1;
            //newBoy.ToString();

            ////隐式转换
            //Boy newGirl = girl2;
            //newGirl.ToString();
        }
        #endregion

        #region 数据结构和算法
        /// <summary>
        /// 数据结构和算法
        /// </summary>
        static void DataStructTest()
        {

            #region 栈的应用 - 计算四则表达式
            //var p1 = ExpressionsHelper.GetPostfixExpression("9+(3-1)*3+10/2");
            //var v1 = ExpressionsHelper.GetPostfixExpressionResult(p1);
            //Console.WriteLine();
            //var p2 = ExpressionsHelper.GetPostfixExpression("1+2*3+(4*5+6)*7");
            //var v2 = ExpressionsHelper.GetPostfixExpressionResult(p2);
            //Console.WriteLine();
            #endregion

            #region KMP模式匹配算法
            //StringHelper.GetNext("ABCDABD",false);
            //StringHelper.GetNext("abab",false);
            //StringHelper.GetNext("abcabc", false);
            //Console.WriteLine();
            //StringHelper.GetNext("abceadec", false);

            //var result = StringHelper.Index("goodgoogle", "google", 0);
            //Console.WriteLine(result);
            #endregion

            #region 无向图-邻接矩阵实现
            //UGAdjacencyMatrix graph = new UGAdjacencyMatrix(9);
            //graph.AddVertex("A");
            //graph.AddVertex("B");
            //graph.AddVertex("C");
            //graph.AddVertex("D");
            //graph.AddVertex("E");
            //graph.AddVertex("F");
            //graph.AddVertex("G");
            //graph.AddVertex("H");
            //graph.AddVertex("I");

            //graph.AddEdge("A", "B");
            //graph.AddEdge("A", "F");
            //graph.AddEdge("B", "C");
            //graph.AddEdge("B", "I");
            //graph.AddEdge("B", "G");
            //graph.AddEdge("C", "I");
            //graph.AddEdge("C", "D");
            //graph.AddEdge("D", "I");
            //graph.AddEdge("D", "G");
            //graph.AddEdge("D", "H");
            //graph.AddEdge("D", "E");
            //graph.AddEdge("E", "H");
            //graph.AddEdge("E", "F");
            //graph.AddEdge("F", "G");
            //graph.AddEdge("G", "H");

            //Console.WriteLine("------深度优先遍历-----");
            //graph.Depth_First_Search();
            //Console.WriteLine("递归-深度优先");
            //graph.DFSTraverse();

            //Console.WriteLine("------广度优先遍历-----");
            //graph.Breadth_First_Search();
            //Console.WriteLine("递归-广度优先");
            //graph.BFSTraverse();
            #endregion

            #region 顺序查找法
            //List<int> list = new List<int> { 1, 5, 34, 7, 989 };
            //for (int i = 3; i < 100000000; i++)
            //{
            //    list.Add(i);
            //}
            //TimeHelper.GetRunTime(FindHelper.Sequential_Search, list, 2);
            //Console.WriteLine();
            //TimeHelper.GetRunTime(FindHelper.Sequential_Search2, list, 2);
            #endregion

            #region 折半查找、二分查找，前提是有序表顺序存储
            //List<int> list = new List<int> { 0, 1, 16, 24, 35, 47, 59, 62, 73, 88, 99 };
            //var result = FindHelper.Binary_Search(list, 8);
            //Console.WriteLine("Binary_Search:{0}", result);
            #endregion

            #region 无向图-邻接表实现
            UGAdjacencyTable graph = new UGAdjacencyTable();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");

            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");
            graph.AddEdge("A", "D");
            graph.AddEdge("B", "C");
            graph.AddEdge("C", "D");

            graph.ShowAllEdge();

            Console.WriteLine();
            graph.RemoveVertex("C");
            graph.ShowAllEdge();

            //Console.WriteLine();
            //graph.RemoveEdge("A", "B");
            //graph.ShowAllEdge();

            //Console.WriteLine();
            //graph.RemoveEdge("A", "C");
            //graph.ShowAllEdge();

            //Console.WriteLine();
            //graph.RemoveEdge("A", "D");
            //graph.ShowAllEdge();

            //Console.WriteLine();
            //graph.RemoveEdge("B", "C");
            //graph.ShowAllEdge();

            //Console.WriteLine();
            //graph.RemoveEdge("C", "D");
            //graph.ShowAllEdge();

            //Console.WriteLine();
            //graph.RemoveVertex("C");
            //graph.ShowAllEdge();

            #endregion
        }
        #endregion

        #region 迭代器
        /// <summary>
        /// 迭代器
        /// </summary>
        static void EnumeratorTest()
        {
            #region switch case
            //string country = "America";
            //const string A = "America";
            //const string F = "France";
            //switch (country)
            //{
            //    case A:
            //        Console.WriteLine("America");
            //        goto case "Britain";
            //    case F:
            //        Console.WriteLine("France");
            //        break;
            //    case "Britain":
            //        Console.WriteLine("Britain");
            //        break;
            //    default:
            //        break;
            //}
            #endregion

            #region foreach 迭代器
            //var list = new List<int> { 1, 5, 34, 7, 989 };

            //foreach (var temp in list)
            //{
            //    //temp++;//会报错
            //    //可以改成以下方式
            //    var t = temp + 1;
            //    Console.WriteLine(t);
            //}

            //1.每次迭代使用独立的枚举器
            //var t1 = list.GetEnumerator();
            //while (t1.MoveNext())
            //{
            //    //遍历迭代器的语法糖,Current属性是只读的，所以无法修改
            //    //t1.Current++;
            //    var itemValue = t1.Current;
            //    Console.WriteLine(itemValue);

            //    //使用 using 执行错误处理和资源清除
            //    using (List<int>.Enumerator t2 = list.GetEnumerator())
            //    {
            //        while (t2.MoveNext())
            //        {
            //            Console.WriteLine(t2.Current);
            //        }
            //    }
            //    Console.WriteLine();
            //}
            ////2.迭代后清除状态
            //var d1 = (IDisposable)t1;
            //d1.Dispose();
            #endregion

            #region 实现迭代
            //var p = new Person[] { new Person("梁", "12"), new Person("梁", "34"), new Person("梁", "56") };
            //var peo = new People<Person>(p);

            ////迭代
            //using (var t1 = peo.GetEnumerator())
            //{
            //    while (t1.MoveNext())
            //    {
            //        t1.Current.ToString();
            //    }
            //}

            ////迭代嵌套
            //using (var t = ((IEnumerable<Person>)peo).GetEnumerator())
            //{
            //    while (t.MoveNext())
            //    {
            //        t.Current.ToString();
            //        foreach (var item in ((IEnumerable<Person>)peo))
            //        {
            //            item.ToString();
            //        }
            //        Console.WriteLine();
            //    }
            //}
            #endregion
        }
        #endregion

        #region 字符
        /// <summary>
        /// 字符char
        /// </summary>
        static void CharTest()
        {
            //char c = '\u0042';
            //Console.WriteLine(c);
            //char c1 = (char)67;
            //Console.WriteLine(c1);
            //char c2 = '\x0041';
            //Console.WriteLine(c2);
        }
        #endregion

    }
}
