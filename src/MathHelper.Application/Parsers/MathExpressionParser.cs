using MathHelper.Application.Enums;
using MathHelper.Application.Models;

namespace MathHelper.Application.Parsers;

public class MathExpressionParser
{
    
    private static (List<string>, List<string>) GetValues(string expression)
    {
        expression = expression.Replace(" ", string.Empty);
        List<string> numbers = RagexTemplates.NumbersRegex()
            .Matches(expression).Select(a => a.Value).ToList();
        List<string> operators = RagexTemplates.OperatorRegex()
           .Matches(expression).Select(a => a.Value).ToList();
        return (numbers, operators);
    }
    
    private static ArithmeticOperation ParseCharOperation(char operation)
    {
        return operation switch
        {
            '+' => ArithmeticOperation.Add,
            '-' => ArithmeticOperation.Subtract,
            '*' => ArithmeticOperation.Multiply,
            '/' => ArithmeticOperation.Divide,
            _ => throw new ArgumentException($"Entered the wrong char"),
        };
    }


}
