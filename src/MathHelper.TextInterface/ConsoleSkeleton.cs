using MathHelper.Application.DataAccess;
using MathHelper.TextInterface.Commands;
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
            return Viewer.CreateMassegesListView(HelpInfo._help);
        }
        else if (string.Equals(command.Name, "divide-into-terms", StringComparison.OrdinalIgnoreCase))
        {
            return CommandController.DivideIntoTermsCommand(command);
        }
        else if (string.Equals(command.Name, "calculate", StringComparison.OrdinalIgnoreCase))
        {
            return CommandController.CalculateCommand(command);
        }
        else if (string.Equals(command.Name, "get-calc-history", StringComparison.OrdinalIgnoreCase))
        {
            return Viewer.CSVRecordsView(FileCSV.ReadRecords());
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
