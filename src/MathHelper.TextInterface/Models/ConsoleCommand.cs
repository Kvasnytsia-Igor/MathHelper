using System.Text.RegularExpressions;

namespace MathHelper.TextInterface.Models;

public partial class ConsoleCommand
{
    private readonly List<string> _arguments;
    public ConsoleCommand(string input)
    {
        string[] stringArray = InputRegex().Split(input);
        _arguments = new List<string>();
        Name = stringArray[0];
        if (stringArray.Length > 0)
        {
            for (int i = 1; i < stringArray.Length; i++)
            {
                string inputArgument = stringArray[i];
                string argument = inputArgument;
                Regex regex = MyRegex1();
                Match match = regex.Match(inputArgument);
                if (match.Captures.Count > 0)
                {
                    var captureQuotedText = MyRegex2();
                    var quoted = captureQuotedText.Match(match.Captures[0].Value);
                    argument = quoted.Captures[0].Value;
                }
                _arguments.Add(argument);
            }
        }
    }
    public string Name { get; set; } = "";
    public IEnumerable<string> Arguments
    {
        get
        {
            return _arguments;
        }
    }

    [GeneratedRegex("(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")]
    private static partial Regex InputRegex();

    [GeneratedRegex("\"(.*?)\"", RegexOptions.Singleline)]
    private static partial Regex MyRegex1();

    [GeneratedRegex("[^\"]*[^\"]")]
    private static partial Regex MyRegex2();
}
