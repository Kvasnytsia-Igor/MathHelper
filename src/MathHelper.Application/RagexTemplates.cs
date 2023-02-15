using System.Text.RegularExpressions;

namespace MathHelper.Application;

partial class RagexTemplates
{
    [GeneratedRegex("([0-9]+([.][0-9]*)?|[.][0-9]+)")]
    public static partial Regex NumbersRegex();

    [GeneratedRegex("[.0-9][-+*/][.0-9]")]
    public static partial Regex OperatorRegex();
}