using General;
using MathHelper.Application.Utilities;

namespace MathHelper.TextInterface.Controllers;

public class NumberController
{
    private static readonly string _help = $"Enter the positive integer number that is less or equal to {ulong.MaxValue}";
    public static string DivideIntoTerms(string numericString)
    {
        if (ulong.TryParse(numericString, out ulong number))
        {
            List<ulong> terms = NumberWorker.DivideIntoTerms(number);
            return Viewer.CreateTermsView(terms, number);
        }
        List<string> messages = new()
        {
            $"Incorrect input: {numericString}",
            _help
        };
        return Viewer.CreateMassegesListView(messages);
    }
    public static string Help()
    {
        return Viewer.CreateSingleMessageView(_help);
    }
}
