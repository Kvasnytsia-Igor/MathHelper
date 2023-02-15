using MathHelper.Application.Enums;
using MathHelper.Application.Models;
using System.Text;

namespace MathHelper.TextInterface;

public class Viewer
{
    public static string CreateTermsView(List<string> list)
    {
        StringBuilder sb = new();
        sb.AppendLine($"Result:_________________________________\n");
        foreach (var item in list)
        {
            sb.AppendLine($"{item}");
        }
        sb.AppendLine($"__________________________________________");
        sb.AppendLine($"Count: {list.Count}");
        return sb.ToString();
    }
    public static string CreateExpressionView(MathExpression mathExpression)
    {
        char opChar = ConvertOpToChar(mathExpression.ArithmeticOperation);
        return $"\n{mathExpression.NumberA}{opChar}{mathExpression.NumberB}={mathExpression.Result}\n";
    }
    private static char ConvertOpToChar(ArithmeticOperation arithmeticOperation)
    {
        if (arithmeticOperation == ArithmeticOperation.Add)
        {
            return '+';
        }
        else if (arithmeticOperation == ArithmeticOperation.Subtract)
        {
            return '-';
        }
        else if (arithmeticOperation == ArithmeticOperation.Multiply)
        {
            return '*';
        }
        else
        {
            return '/';
        }
    }
    public static string CreateMassegesListView(List<string> messages)
    {
        StringBuilder sb = new();
        sb.AppendLine();
        foreach (var message in messages)
        {
            sb.AppendLine($"{message}");
        }
        return sb.ToString();
    }
    public static string CreateSingleMessageView(string message)
    {
        return '\n' + message + '\n';
    }
}
