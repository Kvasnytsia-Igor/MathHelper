using MathHelper.Application.DataAccess;
using MathHelper.Application.Services;
using MathHelper.TextInterface.Controllers;

namespace MathHelper.TextInterface.Commands;

public class CommandController
{
    public static string DivideIntoTermsCommand(ConsoleCommand command)
    {
        if (command.Arguments.Count() != 1)
        {
            return Viewer.CreateSingleMessageView($"The command input doesn't have one agrument");
        }
        List<string> result = NumberService.DivideIntoTerms(command.Arguments.ElementAt(0));
        if (result.Count == 0)
        {
            return Viewer.CreateSingleMessageView($"Incorrect argument - {command.Arguments.ElementAt(0)}");
        }
        return Viewer.CreateTermsView(result);
    }
    public static string CalculateCommand(ConsoleCommand command)
    {
        if (command.Arguments.Count() != 1)
        {
            return Viewer.CreateSingleMessageView($"The command input doesn't have one agrument");
        }
        string res = CalculatorService.Calculate(command.Arguments.ElementAt(0));
        if (string.IsNullOrEmpty(res))
        {
            return Viewer.CreateSingleMessageView($"Incorrect argument - {command.Arguments.ElementAt(0)}");
        }
        return Viewer.CreateExpressionView(command.Arguments.ElementAt(0), res);
    }
    
}
