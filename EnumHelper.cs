using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /// <summary>
    /// 定义特性
    /// </summary>
    public class EnumChineseAttribute : Attribute
    {
        private string m_description;
        public EnumChineseAttribute(string chineseDes)
        {
            m_description = chineseDes;
        }
        public string Description
        {
            get { return m_description; }
        }
    }

    /// <summary>
    /// 定义枚举-普通方式
    /// </summary>
    public enum Color
    {
        [EnumChineseAttribute("红色")]
        Red,
        [EnumChineseAttribute("蓝色")]
        Blue,
        [EnumChineseAttribute("白色")]
        White,
    }
    /// <summary>
    /// 定义枚举-自定义方式
    /// </summary>
    public enum TimeOfDay : sbyte
    {
        Morning = 0,
        Afternoon,
        Evening = 2,
    }

    class EnumHelper
    {
        public static void TransferTest()
        {

            //枚举-》枚举
            TimeOfDay time = TimeOfDay.Evening;
            Color color = (Color)time;//效果相当于Color color = (Color)2;
            Console.WriteLine("enum->enum: {0}", color);

            Console.WriteLine();

            //枚举 -》字符串
            string str = TimeOfDay.Morning.ToString();
            Console.WriteLine("enum->string:{0}", str);

            string str1 = Enum.GetNames(typeof(TimeOfDay))[1];//需要知道枚举值
            Console.WriteLine("enum->string:{0}", str1);

            string str2 = Enum.GetName(typeof(TimeOfDay), 1);//需要知道枚举值
            Console.WriteLine("enum->string:{0}", str2);

            Console.WriteLine();


            //字符串 -》 枚举
            TimeOfDay time2 = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), "Morning");
            Console.WriteLine("string->enum:{0}", time2.ToString());

            TimeOfDay time3;
            if (Enum.TryParse("Morning", out time3))//.net4.0 TryParse
            {
                Console.WriteLine("string->enum:{0}", time3.ToString());
            }
            Console.WriteLine();

            //枚举 -》 整型
            int n1 = (int)Color.Red;
            sbyte b = (sbyte)Color.Red;
            short s = (short)Color.Red;
            long l = (long)Color.Red;
            Console.WriteLine("enum->n1:{0}", n1);
            Console.WriteLine("enum->sbyte:{0}", b);
            Console.WriteLine("enum->short:{0}", s);
            Console.WriteLine("enum->long:{0}", l);


            //数字 -》 枚举
            Color c = (Color)2;
            Console.WriteLine("int->enum:{0}", c.ToString());

            c = (Color)Enum.ToObject(typeof(Color), 0);
            Console.WriteLine("int->enum:{0}", c.ToString());

            int index = 0;
            if (Enum.IsDefined(typeof(Color), index))
            {
                Color c1 = (Color)index;
                Console.WriteLine(c1.ToString());
            }
            if (Enum.IsDefined(typeof(Color), "Red"))
            {
                Color c2= (Color)Enum.Parse(typeof(Color), "Red");
                Console.WriteLine(c2.ToString());
            }
            return;

        }

        public static void AttributeTest()
        {
            Color color = Color.White;
            var chineseName = EnumToAttrName(color);
            Console.WriteLine("{0}:{1}", color, chineseName);

        }

        public static string EnumToAttrName(Enum paramEnum)
        {
            Type paramType = typeof(Color);
            var paramStr = paramEnum.ToString();

            MemberInfo[] memberInfos = paramType.GetMember(paramStr);
            if (memberInfos.Length > 0 && memberInfos[0].IsDefined(typeof(EnumChineseAttribute), false))
            {
                FieldInfo fieldInfo = paramType.GetField(paramStr);
                object[] attArray = fieldInfo.GetCustomAttributes(false);
                EnumChineseAttribute attrib = (EnumChineseAttribute)attArray[0];
                return attrib.Description;
            }
            return null;
        }

    }
}
