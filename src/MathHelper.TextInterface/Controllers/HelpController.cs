namespace MathHelper.TextInterface.Controllers;

public class HelpController
{
    private static readonly List<string> _help = new()
    {
        "Commands",
        "calculate <argument>: " +
        "Enter an arithmetic expression like \'a+b\'",

        "divide-into-terms <argument>: " +
        $"Enter the positive integer number that is less or equal to {ulong.MaxValue}"
};
    public static List<string> GetHelp()
    {
        return _help;
    }
}
