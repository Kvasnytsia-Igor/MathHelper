using MathHelper.Application.Utilities;

namespace MathHelper.TextInterface.Controllers;

public class NumberService
{
    public static List<string> DivideIntoTerms(string numericString)
    {
        if (ulong.TryParse(numericString, out ulong number))
        {
            List<ulong> terms = NumberWorker.DivideIntoTerms(number);
            List<string> result = new(terms.Count);
            foreach (ulong item in terms)
            {
                result.Add(item.ToString());
            }
            return result;
        }
        return new(0);
    }
}
