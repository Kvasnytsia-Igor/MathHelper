using MathHelper.Application.Enums;
using MathHelper.Application.Utilities;

namespace MathHelper.Application.Tests;

public class Caclulator_Tests
{
    [Theory]
    [InlineData(18, 17, ArithmeticOperation.Add, 35)]
    [InlineData(25, 12, ArithmeticOperation.Subtract, 13)]
    [InlineData(9, 9, ArithmeticOperation.Multiply, 81)]
    [InlineData(30, 2, ArithmeticOperation.Divide, 15)]
    [InlineData(16, 9, ArithmeticOperation.Add, 25)]
    [InlineData(81, 41, ArithmeticOperation.Subtract, 40)]
    [InlineData(44, 4, ArithmeticOperation.Divide, 11)]
    public void Calculate_CorrectInput_Equal(decimal first, decimal second, ArithmeticOperation operation, decimal expected)
    {
        decimal actual = Calculator.CalculateTwoNumbers(first, second, operation);
        Assert.Equal(expected, actual);
    }
}
