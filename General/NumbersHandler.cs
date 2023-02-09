namespace General;

public class NumbersHandler
{
    private const ulong TEN_QUINTILLION = 10_000_000_000_000_000_000;
    // parsing a number into one-digit terms
    public static List<ulong> ParseIntoOneDigitTerms(ulong number)
    {
        List<ulong> result = new();
        if (number == 0)
        {
            return result;
        }
        ulong firstNum = GetFirstOneDigitTerm(number);
        for (ulong i = 10, temp = number; temp != firstNum; i *= 10)
        {
            ulong res1 = temp % i;
            result.Add(res1);
            temp -= res1;
        }
        result.Add(firstNum);
        result.RemoveAll(x => x == 0);
        result.Reverse();
        return result;
    }
    private static ulong GetFirstOneDigitTerm(ulong number)
    {
        for (ulong i = TEN_QUINTILLION; i >= 0; i /= 10)
        {
            if (number >= i)
            {
                number = number / i * i;
                break;
            }
        }
        return number;
    }
}
