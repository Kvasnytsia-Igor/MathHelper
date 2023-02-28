using System.Text.RegularExpressions;

namespace MathHelper.Application;

public partial class RagexTemplates
{
    [GeneratedRegex(@"([0-9]+)")]
    public static partial Regex NumbersRegex();

    [GeneratedRegex("[-+*/]")]
    public static partial Regex OperatorRegex();

    [GeneratedRegex(@"([*+/\-)(])|([0-9]+)")]
    public static partial Regex MathExpressionRages();
}