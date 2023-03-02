using MathHelper.Application.DataAccess;
using MathHelper.Application.Utilities;

namespace MathHelper.Application.Services;

public class CalculatorService
{
    public static string Calculate(string exp)
    {
        try
        {
            string res = Calculator.CalculateExpression(exp);
            FileCSV.WriteCSVLine($"{exp}={res};{DateTime.Now}");
            return res;
        }
        catch (FormatException)
        {
            return "";
        }
    }
}
