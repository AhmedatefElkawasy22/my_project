using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahmedc_1.frist_work
{
    internal static class expressionParser
    {
        private const string MathSymbols = "*+/^%";
        public static MathExpression parse(string input)
        {
            var expr = new MathExpression();
            string token = "";
            bool leftSideInitialized = false;
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                if (char.IsDigit(currentChar))
                {
                    token += currentChar;
                    if (leftSideInitialized && i == input.Length - 1)
                    {
                        expr.rightSideOprand = double.Parse(token);
                        break;
                    }
                }
                else if (char.IsLetter(currentChar))
                {
                    token += currentChar;
                    leftSideInitialized = true;
                }
                else if (MathSymbols.Contains(currentChar)) 
                {
                    if (!leftSideInitialized)
                    {
                        expr.leftSideOprand = double.Parse(token);
                        leftSideInitialized = true;
                    }
                    expr.opration = paresMathOperation(currentChar.ToString());
                    token = "";
                }
                else if (currentChar == '-' && i > 0)
                {
                    if (expr.opration == mathOpration.None)
                    {
                        expr.opration = mathOpration.subtraction;
                        expr.leftSideOprand = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";
                    }
                    else
                    {
                        token += currentChar;
                    }
                }
                else if (currentChar == ' ')
                {
                    if (!leftSideInitialized)
                    {
                        expr.leftSideOprand = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";
                    }
                    else if (expr.opration == mathOpration.None)
                    {
                        expr.opration = paresMathOperation(token);
                        token = "";
                    }
                    // expr.leftSideOprand = double.Parse(token);
                }
                else
                {
                    token += currentChar;
                }
            }

            return expr;
        }

        private static mathOpration paresMathOperation(string token)
        {
            switch (token.ToLower())
            {
                case "+":
                    return mathOpration.Addition;
                case "-":
                    return mathOpration.subtraction;
                case "*":
                    return mathOpration.multiplication;
                case "/":
                    return mathOpration.division;
                case "%":
                case "mod":
                    return mathOpration.modulus;
                case "^":
                case "power":
                    return mathOpration.power;
                case "sin":
                    return mathOpration.sin;
                case "cos":
                    return mathOpration.cos;
                case "tan":
                    return mathOpration.tan;
                default:
                    return mathOpration.None;

            }
        }
    }
}
