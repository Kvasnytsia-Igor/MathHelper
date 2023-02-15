using System.Text.RegularExpressions;

namespace MathHelper;

public class ConsoleCommand
{
    private readonly List<string> _arguments;
    public ConsoleCommand(string input)
    {
        var stringArray = Regex.Split(input, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
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
                // Is the argument a quoted text string?
                var regex = new Regex("\"(.*?)\"", RegexOptions.Singleline);
                var match = regex.Match(inputArgument);

                if (match.Captures.Count > 0)
                {
                    // Get the unquoted text:
                    var captureQuotedText = new Regex("[^\"]*[^\"]");
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
}
