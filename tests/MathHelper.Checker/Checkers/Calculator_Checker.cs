using MathHelper.Application.Models;
using MathHelper.Application.Utilities;

namespace MathHelper.Checker.Checkers;

public class Calculator_Checker
{
    public static void CalculateExpressions()
    {
        string[] expressions =
        {
            "18+17",
            "25-12",
            "9*9",
            "30/2",
            "16+9",
            "81-41",
            "7*11",
            "44/4"
        };
        for (int i = 0; i < expressions.Length; i++)
        {
            string result = Calculator.CalculateExpression(expressions[i]);
            Console.WriteLine($"{i + 1}){result}");
        }
    }
    public static void CalculateExpressionsV2()
    {
        string[] expressions =
        {
            "(45+5)/10*4+12"
        };
        for (int i = 0; i < expressions.Length; i++)
        {
            string result = Calculator.CalculateExpression(expressions[i]);
            Console.WriteLine($"{i + 1}){result}");
        }

    }
}
