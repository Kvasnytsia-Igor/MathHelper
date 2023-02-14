using System.Text;

namespace General;

public class Viewer
{
    public static string CreateTermsView(List<ulong> list, ulong number)
    {
        StringBuilder sb = new();
        sb.AppendLine($"\nInput: {number}");
        sb.AppendLine($"Result:_________________________________\n");
        foreach (var item in list)
        {
            sb.AppendLine($"{item}");
        }
        sb.AppendLine($"__________________________________________");
        sb.AppendLine($"Count: {list.Count}");
        return sb.ToString();
    }
    public static string CreateMassegesListView(List<string> messages)
    {
        StringBuilder sb = new();
        sb.AppendLine();
        foreach (var message in messages)
        {
            sb.AppendLine($"{message}");
        }
        return sb.ToString();
    }
    public static string CreateSingleMessageView(string message)
    {
        return '\n' + message + '\n';
    }
}
