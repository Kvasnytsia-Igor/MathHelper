using System.Text.RegularExpressions;

namespace MathHelper.TextInterface.Commands;

public partial class ConsoleCommand
{
    private readonly List<string> _arguments;
    public ConsoleCommand(string input)
    {
        var stringArray = SplitRegex().Split(input);
        _arguments = new List<string>();
        for (int i = 0; i < stringArray.Length; i++)
        {
            if (i == 0)
            {
                Name = stringArray[i];
            }
            else
            {
                var inputArgument = stringArray[i];
                string argument = inputArgument;
                var regex = QuotedTextRegex();
                var match = regex.Match(inputArgument);
                if (match.Captures.Count > 0)
                {
                    var captureQuotedText = UnquotedTextRegex();
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
    private static partial Regex SplitRegex();

    [GeneratedRegex("\"(.*?)\"", RegexOptions.Singleline)]
    private static partial Regex QuotedTextRegex();

    [GeneratedRegex("[^\"]*[^\"]")]
    private static partial Regex UnquotedTextRegex();
}
