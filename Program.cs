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
            ExpressionsHelper.GetPostfixExpression("9+(3-1)*3+10/2");
            ExpressionsHelper.GetPostfixExpression("1+2*3+(4*5+6)*7");
        }
    }


    
}
