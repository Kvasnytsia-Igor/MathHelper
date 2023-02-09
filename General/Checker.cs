using System.Diagnostics;

namespace General;

public class Checker
{
    public static void Check_ParseIntoOneDigitTerms()
    {
        try
        {
            ulong input = ulong.MaxValue;
            Stopwatch stopWatch = new();
            stopWatch.Start();
            List<ulong> result = NumbersHandler.ParseIntoOneDigitTerms(input);
            stopWatch.Stop();
            string ticks = $"Ticks: {stopWatch.ElapsedTicks}";
            string view = Viewer.CreateString(result, input);
            Console.WriteLine($"{view}\n{ticks}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        
    }
}
