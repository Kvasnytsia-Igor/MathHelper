using System.Text;

namespace MathHelper.Checker;

public class ViewBuilder
{
    public static string ShowArr(byte[] arr)
    {
        StringBuilder sb = new();
        foreach (byte b in arr)
        {
            sb.Append($"{b}");
        }
        return sb.ToString();
    }
}
