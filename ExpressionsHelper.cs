using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataStructure
{
    /// <summary>
    /// 栈的应用-计算四则表达式
    /// 1、将中缀表达式转换成后缀表达式
    /// 2、使用后缀表达式进行运算，得出结果
    /// </summary>
    class ExpressionsHelper
    {
        private static List<string> hightPriority = new List<string> { "*", "/", "(", ")" };
        private static List<string> lowPriority = new List<string> { "+", "-" };
        /// <summary>
        /// 将中缀表达式转换成后缀表达式
        /// 标准四则运算表达式->中缀表达式：所有运算负号都在两数字中间
        /// 1、从左到右遍历中缀表达式的每个数字和符号
        /// 2、是数字就输出，是符号则判断与栈顶符号的优先级，
        /// 3、当前符号优先级大于栈顶符号，入栈
        /// 4、当前符号优先级低于或等于栈顶符号或者当前符号是右括号，栈顶元素依次出栈，将当前符号进栈
        /// 5、遇到右括号才弹出左括号
        /// 测试用例：9 + ( 3 - 1 ) * 3 + 10 / 2 期望结果：9 3 1 - 3 * + 10 2 / +
        /// 测试用例：1 + 2 * 3 + ( 4 * 5 + 6 ) * 7 期望结果：1 2 3 * + 4 5 * 6 + 7 * +
        /// </summary>
        /// <param name="infixExpression"></param>
        /// <returns></returns>
        public static string GetPostfixExpression(string infixExpression)
        {
            Stack<string> tmpStack = new Stack<string>();
            List<string> resultList = new List<string>();
            List<string> tmp=new List<string>();
            //提取+-*/数组和括号
            foreach (Match match in Regex.Matches(infixExpression, @"([+\-*/\(\)])|(\d+)"))
                tmp.Add(match.Value);

            foreach (var item in tmp)
            {
                if(item=="")
                {
                    continue;
                }
                if (isNumberic(item))//数字输出
                {
                    resultList.Add(item);
                }
                else//符号入栈
                {
                    //只有遇到右括号的时候左括号才会弹出
                    if (item == ")")
                    {
                        while (tmpStack.Peek() != "(")
                        {
                            var top = tmpStack.Pop();
                            resultList.Add(top);
                        }
                        if (tmpStack.Peek() == "(")
                        {
                            tmpStack.Pop();
                        }
                    }
                    else
                    {
                        //优先级：栈顶<当前，当前符号优先级高于栈顶符号，入栈
                        if (tmpStack.Count == 0 || isLowPirority(tmpStack.Peek(), item) || tmpStack.Peek() == "(")
                        {
                            tmpStack.Push(item);
                        }
                        else
                        {
                            //优先级：栈顶>=当前，当前符号优先级低于或等于栈顶符号，栈顶元素依次出栈，将当前符号进栈，遇到左扩号停止弹出行为。
                            while (tmpStack.Count > 0 && !isLowPirority(tmpStack.Peek(), item))
                            {
                                if (tmpStack.Peek() == "(")
                                {
                                    break;
                                }
                                var top = tmpStack.Pop();
                                resultList.Add(top);
                            }
                            tmpStack.Push(item);
                        }
                    }
                }
            }
            //数据已经读到末尾，栈中符号直接弹出并输出
            while (tmpStack.Count != 0)
            {
                var top = tmpStack.Pop();
                resultList.Add(top);
            }
            //空格分隔
            var result = string.Join(" ", resultList);
            Console.WriteLine("中缀表达式：{0}",infixExpression);
            Console.WriteLine("后缀表达式：{0}", result);
            return result;
        }

        /// <summary>
        /// 使用后缀表达式进行运算，得出结果(每个输入都要用空格分隔）
        /// 规则
        /// 1、从左到右遍历表达式的每个数字和符号
        /// 2、遇到数字就进栈，遇到符号就将处于栈顶的两个数字出栈运算，运算结果进栈。
        /// </summary>
        /// <param name="postfixExpression"></param>
        /// <returns></returns>
        public static int GetPostfixExpressionResult(string postfixExpression)
        {
            Stack<int> tmpStack = new Stack<int>();
            string[] tmp = Regex.Split(postfixExpression, "\\s+", RegexOptions.IgnoreCase);

            foreach (var item in tmp)
            {
                if (isNumberic(item))
                {
                    tmpStack.Push(int.Parse(item));
                }
                else
                {
                    var b = tmpStack.Pop();
                    var a = tmpStack.Pop();
                    var tmpResult = getResult(a, item, b);
                    tmpStack.Push(tmpResult);
                }
            }          
            var result = tmpStack.Pop();
            if (tmpStack.Count > 0)
            {
                throw new Exception("后缀表达式错误");
            }
            Console.WriteLine("运算结果:{0}",result);
            return result;
        }

        private static int getResult(int a, string symbol, int b)
        {
            int result = 0;
            switch (symbol)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
                default:
                    break;
            }
            return result;
        }
        /// <summary>
        /// c1<c2 true
        /// c1>=c2 false
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool isLowPirority(string c1, string c2)
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
        public static bool isNumberic(string num)
        {
            int i;
            bool result = int.TryParse(num, out i);
            return result;
        }
    }
}
