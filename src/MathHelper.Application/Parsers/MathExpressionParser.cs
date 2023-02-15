using MathHelper.Application.Enums;
using MathHelper.Application.Models;

namespace MathHelper.Application.Parsers;

public class MathExpressionParser
{
    public static bool TryParse(string expression, out MathExpression mathExpression)
    {
        mathExpression = new MathExpression();
        (List<string> numbers, List<string> operators) = GetValues(expression);
        return Parse(numbers, operators, mathExpression);
    }
    private static (List<string>, List<string>) GetValues(string expression)
    {
        expression = expression.Replace(" ", string.Empty);
        List<string> numbers = RagexTemplates.NumbersRegex()
            .Matches(expression).Select(a => a.Value).ToList();
        List<string> operators = RagexTemplates.OperatorRegex()
           .Matches(expression).Select(a => a.Value).ToList();
        return (numbers, operators);
    }
    private static bool Parse(List<string> numbers, List<string> operators, in MathExpression mathExpression)
    {
        if (numbers.Count != 2)
        {
            return false;
        }
        if (operators.Count != 1)
        {
            return false;
        }
        if (!decimal.TryParse(numbers.First(), out decimal first))
        {
            throw new Exception($"{numbers.First()} could not be parsed");
        }
        if (!decimal.TryParse(numbers.Last(), out decimal second))
        {
            throw new Exception($"{numbers.Last()} could not be parsed");
        }
        char arithOperator = operators.First().Skip(1).Take(1).First();
        ArithmeticOperation arithmeticOperation = ParseCharOperation(arithOperator);
        mathExpression.NumberA = first;
        mathExpression.NumberB = second;
        mathExpression.ArithmeticOperation = arithmeticOperation;
        return true;
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
