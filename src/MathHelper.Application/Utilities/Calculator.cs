using MathHelper.Application.Enums;
using MathHelper.Application.Models;

namespace MathHelper.Application.Utilities;

public class Calculator
{
    private const decimal ONE_MILLION = 1_000_000_000;
    public static MathExpression CalculateTwoNumbers(MathExpression mathExpression)
    {
        if (Math.Abs(mathExpression.NumberA) > ONE_MILLION || Math.Abs(mathExpression.NumberB) > ONE_MILLION)
        {
            string exOut = "";
            if (Math.Abs(mathExpression.NumberA) > ONE_MILLION)
            {
                exOut += $"{mathExpression.NumberA} > {ONE_MILLION} ";
            }
            if (Math.Abs(mathExpression.NumberB) > ONE_MILLION)
            {
                exOut += $"{mathExpression.NumberB} > {ONE_MILLION} ";
            }
            throw new ArgumentException(exOut);
        }
        decimal result = mathExpression.ArithmeticOperation switch
        {
            ArithmeticOperation.Add => mathExpression.NumberA + mathExpression.NumberB,
            ArithmeticOperation.Subtract => mathExpression.NumberA - mathExpression.NumberB,
            ArithmeticOperation.Multiply => mathExpression.NumberA * mathExpression.NumberB,
            ArithmeticOperation.Divide => mathExpression.NumberA / mathExpression.NumberB,
            _ => throw new ArithmeticException(),
        };
        mathExpression.Result = Math.Round(result, 9);
        mathExpression.IsSuccess = true;
        return mathExpression;
    }
}
