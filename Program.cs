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
            var p1 = ExpressionsHelper.GetPostfixExpression("9+(3-1)*3+10/2");
            var v1 = ExpressionsHelper.GetPostfixExpressionResult(p1);
            Console.WriteLine();
            var p2 = ExpressionsHelper.GetPostfixExpression("1+2*3+(4*5+6)*7");
            var v2 = ExpressionsHelper.GetPostfixExpressionResult(p2);
        }
    }
}
