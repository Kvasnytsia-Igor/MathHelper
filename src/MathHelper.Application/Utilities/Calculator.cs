using MathHelper.Application.Models;

namespace MathHelper.Application.Utilities;

public class Calculator
{
    public static string CalculateExpression(string expression)
    {
        Calculation calculation = StringToExpression(expression);
        decimal res = Solve(calculation);
        return res.ToString();
    }
    private static Calculation StringToExpression(string exp)
    {
        if (!CheckSpaceBetweenBrackets(exp))
        {
            exp = exp.Trim('(', ')');
        }
        char operatorExp = GetCharOperator(exp, new char[] { '+', '-' }, out int index);
        if (index == -1)
        {
            operatorExp = GetCharOperator(exp, new char[] { '*', '/' }, out index);
        }
        if (index != -1)
        {
            string leftPart = exp[..index];
            string rightPart = exp[(index + 1)..];
            Calculation calculation = new()
            {
                LeftHandValue = StringToExpression(leftPart),
                RightHandValue = StringToExpression(rightPart),
                Function = CalcFunc(operatorExp),
            };
            return calculation;
        }
        return new Calculation
        {
            CurrentValue = decimal.Parse(exp)
        };
    }
    private static decimal Solve(Calculation calc)
    {
        if (calc.CurrentValue.HasValue)
        {
            return calc.CurrentValue.Value;
        }
        if (calc.LeftHandValue is null)
        {
            throw new NullReferenceException($"Left leaf with num can't be null");
        }
        if (!calc.LeftHandValue.CurrentValue.HasValue)
        {
            calc.LeftHandValue.CurrentValue = Solve(calc.LeftHandValue);
        }
        if (calc.RightHandValue is null)
        {
            throw new NullReferenceException($"Right leaf with num can't be null");
        }
        if (!calc.RightHandValue.CurrentValue.HasValue)
        {
            calc.RightHandValue.CurrentValue = Solve(calc.RightHandValue);
        }
        if (calc.Function is null)
        {
            throw new NullReferenceException($"Function can't be null");
        }
        calc.CurrentValue = calc.Function(calc.LeftHandValue.CurrentValue.Value, calc.RightHandValue.CurrentValue.Value);
        return calc.CurrentValue.Value;
    }
    private static bool CheckSpaceBetweenBrackets(string exp)
    {
        int bracketsСount = 0;
        for (int i = 0; i < exp.Length; i++)
        {
            if (exp[i] == '(')
            {
                bracketsСount++;
            }
            if (bracketsСount == 0)
            {
                return true;
            }
            if (exp[i] == ')')
            {
                bracketsСount--;
            }
        }
        return false;
    }
    private static char GetCharOperator(string exp, char[] operators, out int index)
    {
        int bracketsСount = 0;
        for (int i = exp.Length - 1; i >= 0; i--)
        {
            if (exp[i] == ')')
            {
                bracketsСount++;
            }
            else if (exp[i] == '(')
            {
                bracketsСount--;
            }
            for (int j = 0; j < operators.Length; j++)
            {
                if (exp[i] == operators[j] && bracketsСount == 0)
                {
                    index = i;
                    return operators[j];
                }
            }
        }
        index = -1;
        return ' ';
    }
    private static Func<decimal, decimal, decimal> CalcFunc(char mathOperator)
    {
        return mathOperator switch
        {
            '+' => (left, right) => left + right,
            '-' => (left, right) => left - right,
            '*' => (left, right) => left * right,
            '/' => (left, right) => left / right,
            _ => throw new ArgumentException($"\'{mathOperator}\' - incorrect char"),
        };
    }
}
