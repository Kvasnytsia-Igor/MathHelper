namespace MathHelper.TextInterface;

public class HelpInfo
{
    public static readonly List<string> _help = new()
    {
        "Commands:\n",

        "calculate [expression]\n" +
        "Сalculates the result of a mathematical expression\n",

        "get-calc-history\n" +
        "Gets the history of mathematical calculations\n",

        "divide-into-terms [number]\n" +
        "Divides a number into digit terms\n",

        "exit\n" +
        "End the program execution"
    };
}
