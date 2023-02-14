using MathHelper.Application.Utilities;

namespace MathHelper.Application.Tests;

public class NumberServiceTests
{
    #region ParseIntoOneDigitTerms
    [Theory]
    [InlineData(25, 2)]
    [InlineData(12304060789, 8)]
    [InlineData(ulong.MinValue, 0)]
    [InlineData(ulong.MaxValue, 18)]
    public void ParseIntoOneDigitTerms_Number_ResultCount(ulong input, int count)
    {
        // act
        List<ulong> result = NumberWorker.DivideIntoTerms(input);
        // assert
        Assert.Equal(count, result.Count);
    }

    [Theory]
    [InlineData(12304060789, new ulong[]
    {
        10000000000,
        2000000000,
        300000000,
        4000000,
        60000,
        700,
        80,
        9
    })]
    [InlineData(25, new ulong[]
    {
        20,
        5
    })]
    [InlineData(ulong.MaxValue, new ulong[]
    {
        10000000000000000000,
        8000000000000000000,
        400000000000000000,
        40000000000000000,
        6000000000000000,
        700000000000000,
        40000000000000,
        4000000000000,
        70000000000,
        3000000000,
        700000000,
        9000000,
        500000,
        50000,
        1000,
        600,
        10,
        5
    })]
    public void ParseIntoOneDigitTerms_Number_Collection(ulong input, ulong[] array)
    {
        // act
        List<ulong> result = NumberWorker.DivideIntoTerms(input);
        // assert
        for (int i = 0; i < array.Length; i++)
        {
            Assert.Equal(array[i], result[i]);
        }
    }
    #endregion
}