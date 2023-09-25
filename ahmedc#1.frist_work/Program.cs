using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace ahmedc_1.frist_work
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("please enter math expression: ");
                var input= Console.ReadLine();
                var expr=expressionParser.parse(input);
                //Console.WriteLine("left side: "+expr.leftSideOprand);
                //Console.WriteLine("right side: "+expr.rightSideOprand);
                //Console.WriteLine("opration: "+expr.opration);
                Console.WriteLine($"{input}={EvaluateExpression(expr)}");
                if(input=="OFF"|| input == "off") { break; }
            }
        }

        private static object EvaluateExpression(MathExpression expr)
        {
           switch (expr.opration)
            {
                case mathOpration.Addition:
                    return expr.leftSideOprand + expr.rightSideOprand;
                case mathOpration.subtraction:
                    return expr.leftSideOprand - expr.rightSideOprand;
                case mathOpration.multiplication:
                    return expr.leftSideOprand * expr.rightSideOprand;
                case mathOpration.division:
                    return expr.leftSideOprand / expr.rightSideOprand;
                case mathOpration.modulus:
                    return expr.leftSideOprand % expr.rightSideOprand;
                case mathOpration.power:
                    return Math.Pow(expr.leftSideOprand,expr.rightSideOprand);
                case mathOpration.sin:
                    return Math.Sin(expr.rightSideOprand);
                case mathOpration.cos:
                    return Math.Cos(expr.rightSideOprand);
                case mathOpration.tan:
                    return Math.Tan(expr.rightSideOprand);
                default:
                    return 0;

            }
        }
    }
}
