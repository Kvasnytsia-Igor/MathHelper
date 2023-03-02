using System.Text;

namespace MathHelper.TextInterface;

public class Viewer
{
    public static string CSVRecordsView(string[] records)
    {
        StringBuilder sb = new();
        string[][] matrix = records.Select(a => a.Split(';')).ToArray();
        int maxLen = matrix.Select(a => a[0].Length).Max();
        foreach (string[] splited in matrix)
        {
            string modified = splited[0].PadRight(maxLen + 5, ' ') + splited[1];
            sb.AppendLine(modified);
        }
        return sb.ToString();
    }
    public static string CreateTermsView(List<string> list)
    {
        StringBuilder sb = new();
        foreach (var item in list)
        {
            sb.AppendLine($"{item}");
        }
        sb.AppendLine($"Count: {list.Count}");
        return sb.ToString();
    }
    public static string CreateExpressionView(string exp, string res)
    {
        StringBuilder sb = new();
        sb.AppendLine($"{exp}={res}");
        return sb.ToString();
    }
    public static string CreateMassegesListView(List<string> messages)
    {
        StringBuilder sb = new();
        foreach (var message in messages)
        {
            sb.AppendLine($"{message}");
        }
        return sb.ToString();
    }
    public static string CreateSingleMessageView(string message)
    {
        return message + '\n';
    }
}
