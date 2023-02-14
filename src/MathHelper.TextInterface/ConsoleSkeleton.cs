using MathHelper.TextInterface.Controllers;

namespace MathHelper.TextInterface;

public class ConsoleSkeleton
{
    public static void Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            string? consoleInput = ReadFromConsole();
            if (string.IsNullOrWhiteSpace(consoleInput))
            {
                continue;
            }
            try
            {
                consoleInput = consoleInput.Trim();
                if (string.Equals(consoleInput, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    isRunning = false;
                }
                else
                {
                    string result = Execute(consoleInput);
                    WriteToConsole(result);
                }
            }
            catch (Exception ex)
            {
                isRunning = false;
                WriteToConsole(ex.Message);
            }
        }
    }
    private static string Execute(string command)
    {
        if (string.Equals(command, "help", StringComparison.OrdinalIgnoreCase))
        {
            return NumberController.Help();
        }
        return NumberController.DivideIntoTerms(command);
    }
    private static void WriteToConsole(string message = "")
    {
        if (message.Length > 0)
        {
            Console.WriteLine(message);
        }
        else
        {
            throw new ArgumentException("Message is empty");
        }
    }
    private const string _readPrompt = "DivideIntoTerms >> ";
    private static string? ReadFromConsole(string promptMessage = "")
    {
        Console.Write(_readPrompt + promptMessage);
        return Console.ReadLine();
    }
}
