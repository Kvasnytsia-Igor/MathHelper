using System.Text;

namespace General;

public class Viewer
{
    public static string CreateString(List<ulong> list, ulong number)
    {
        StringBuilder sb = new();
        sb.AppendLine($"Input: {number}");
        sb.AppendLine($"Result:_________________________________\n");
        foreach (var item in list)
        {
            sb.AppendLine($"{item}");
        }
        sb.AppendLine($"__________________________________________");
        sb.AppendLine($"Count: {list.Count}");
        return sb.ToString();
    }
}
