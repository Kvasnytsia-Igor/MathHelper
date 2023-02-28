using MathHelper.Application.Utilities;

namespace MathHelper.Application.Tests;

public class Calculator_Tests
{
    [Theory]
    [InlineData("18+17", "35")]
    [InlineData("25-12", "13")]
    [InlineData("9*9", "81")]
    [InlineData("30/2", "15")]
    [InlineData("16+9", "25")]
    [InlineData("81-41", "40")]
    [InlineData("7*11", "77")]
    [InlineData("44/4", "11")]
    public void CalculateExpression_TwoNumsExpression_Equal(string exp, string expected)
    {
        string actual = Calculator.CalculateExpression(exp);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("(24/8+14)*2-15", "19")]
    [InlineData("(45+5)/10*4+12", "32")]
    [InlineData("(44-14)/3+12*3", "46")]
    [InlineData("(16+24)/4-4*2", "2")]
    public void CalculateExpression_LargeExpression_Equal(string exp, string expected)
    {
        string actual = Calculator.CalculateExpression(exp);
        Assert.Equal(expected, actual);
    }
}
