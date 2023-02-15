using MathHelper.Application.Models;
using MathHelper.Application.Parsers;
using MathHelper.Application.Utilities;

namespace MathHelper.TextInterface.Controllers;

public class CalculatorController
{
    public static MathExpression Calculate(string expression)
    {
        if (MathExpressionParser.TryParse(expression, out MathExpression mathExpression))
        {
            Calculator.CalculateTwoNumbers(mathExpression);
        }
        return mathExpression;
    }
}
