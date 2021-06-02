using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /// <summary>
    /// 栈的应用-计算四则表达式
    /// 1、将中缀表达式转换成后缀表达式
    /// 2、使用后缀表达式进行运算，得出结果
    /// </summary>
    class ExpressionsHelper
    {
        private static List<char> hightPriority = new List<char> { '*', '/', '(', ')' };
        private static List<char> lowPriority = new List<char> { '+', '-' };
        /// <summary>
        /// 将中缀表达式转换成后缀表达式
        /// 标准四则运算表达式->中缀表达式：所有运算负号都在两数字中间
        /// 1、从左到右遍历中缀表达式的每个数字和符号
        /// 2、是数字就输出，是符号则判断与栈顶符号的优先级，
        /// 3、当前符号优先级大于栈顶符号，入栈
        /// 4、当前符号优先级低于或等于栈顶符号或者当前符号是右括号，栈顶元素依次出栈，将当前符号进栈
        /// 5、遇到右括号才弹出左括号
        /// 测试用例：9+(3-1)*3+10/2 期望结果：931-3*+102/+
        /// 测试用例：1+2*3+(4*5+6)*7 期望结果：123*+45*6+7*+
        /// </summary>
        /// <param name="infixExpression"></param>
        /// <returns></returns>
        public static string GetPostfixExpression(string infixExpression)
        {
            Stack<char> tmpStack = new Stack<char>();
            List<char> resultArr = new List<char>();
            foreach (char c in infixExpression)
            {
                if (isNumberic(c))//数字输出
                {
                    resultArr.Add(c);
                }
                else//符号入栈
                {
                    //只有遇到右括号的时候左括号才会弹出
                    if (c == ')')
                    {
                        while (tmpStack.Peek() != '(')
                        {
                            char top = tmpStack.Pop();
                            resultArr.Add(top);
                        }
                        if (tmpStack.Peek() == '(')
                        {
                            tmpStack.Pop();
                        }
                    }
                    else
                    {
                        //优先级：栈顶<当前，当前符号优先级高于栈顶符号，入栈
                        if (tmpStack.Count == 0 || isLowPirority(tmpStack.Peek(), c) || tmpStack.Peek() == '(')
                        {
                            tmpStack.Push(c);
                        }
                        else
                        {
                            //优先级：栈顶>=当前，当前符号优先级低于或等于栈顶符号，栈顶元素依次出栈，将当前符号进栈，遇到左扩号停止弹出行为。
                            while (tmpStack.Count > 0 && !isLowPirority(tmpStack.Peek(), c))
                            {
                                if (tmpStack.Peek() == '(')
                                {
                                    break;
                                }
                                char top = tmpStack.Pop();
                                resultArr.Add(top);
                            }
                            tmpStack.Push(c);
                        }
                    }
                }
            }
            //数据已经读到末尾，栈中符号直接弹出并输出
            while (tmpStack.Count != 0)
            {
                char top = tmpStack.Pop();
                resultArr.Add(top);
            }
            string result = new string(resultArr.ToArray());
            Console.WriteLine(result);
            return result;
        }

        /// <summary>
        /// c1<c2 true
        /// c1>=c2 false
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool isLowPirority(char c1, char c2)
        {
            bool isC1InLow = lowPriority.Contains(c1);
            bool isC2InHight = hightPriority.Contains(c2);
            return isC1InLow && isC2InHight;
        }

        /// <summary>
        /// 判断是否数字
        /// 还可以使用正则、ASCII码等方式判断
        /// </summary>
        /// <param name="numChar"></param>
        /// <returns></returns>
        public static bool isNumberic(char numChar)
        {
            int i;
            bool result = int.TryParse(numChar.ToString(), out i);
            return result;
        }
    }
}
