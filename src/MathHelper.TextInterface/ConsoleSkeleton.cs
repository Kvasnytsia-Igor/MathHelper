using MathHelper.Application.Models;
using MathHelper.TextInterface.Controllers;
using System.Globalization;

namespace MathHelper.TextInterface;

public class ConsoleSkeleton
{
    static ConsoleSkeleton()
    {
        Console.Title = "MathHelper";
        CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
    }
    private static bool isRunning = true;
    public static void Run()
    {
        while (isRunning)
        {
            string? consoleInput = ReadFromConsole();
            if (string.IsNullOrWhiteSpace(consoleInput))
            {
                continue;
            }
            try
            {
                var cmd = new ConsoleCommand(consoleInput);
                string result = Execute(cmd);
                if (isRunning)
                {
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
    private static string Execute(ConsoleCommand command)
    {
        if (string.Equals(command.Name, "exit", StringComparison.OrdinalIgnoreCase))
        {
            isRunning = false;
        }
        else if (string.Equals(command.Name, "help", StringComparison.OrdinalIgnoreCase))
        {
            return Viewer.CreateMassegesListView(HelpController.GetHelp());
        }
        else if (string.Equals(command.Name, "divide-into-terms", StringComparison.OrdinalIgnoreCase))
        {
            if (command.Arguments.Count() != 1)
            {
                return Viewer.CreateSingleMessageView($"The command input doesn't have one agrument");
            }
            List<string> result = NumberController.DivideIntoTerms(command.Arguments.ElementAt(0));
            if (result.Count == 0)
            {
                return Viewer.CreateSingleMessageView($"Incorrect number input");
            }
            return Viewer.CreateTermsView(result);
        }
        else if (string.Equals(command.Name, "calculate", StringComparison.OrdinalIgnoreCase))
        {
            if (command.Arguments.Count() != 1)
            {
                return Viewer.CreateSingleMessageView($"The command input doesn't have one agrument");
            }
            MathExpression expression = CalculatorController.Calculate(command.Arguments.ElementAt(0));
            if (!expression.IsSuccess)
            {
                return Viewer.CreateSingleMessageView($"Incorrect argument - {command.Arguments.ElementAt(0)}");
            }
            return Viewer.CreateExpressionView(expression);
        }
        return Viewer.CreateSingleMessageView($"The command {command.Name} doesn't exist");
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
    private const string _readPrompt = "MathHelper >> ";
    private static string? ReadFromConsole(string promptMessage = "")
    {
        Console.Write(_readPrompt + promptMessage);
        return Console.ReadLine();
    }
}
