using MathHelper.Application.Utilities;

namespace MathHelper.Checker.Checkers;

public class NumberWorker_Checker
{
    public static void DivideIntoTerms()
    {
        ulong[] numbers =
        {
            347,6401,72392,100101,550505,930936
        };
        for (int i = 0; i < numbers.Length; i++)
        {
            List<ulong> terms = NumberWorker.DivideIntoTerms(numbers[i]);
            Console.WriteLine($"{i + 1}){numbers[i]}");
            foreach (ulong term in terms)
            {
                Console.WriteLine($"\t{term}");
            }
        }

    }
}
