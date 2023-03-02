namespace MathHelper.Application.DataAccess;

public class FileCSV
{
    public static void WriteCSVLine(string line)
    {
        File.AppendAllText("PrevResults.csv", line + '\n');
        string[] records = File.ReadAllLines("PrevResults.csv");
        if (records.Length > 20)
        {
            File.WriteAllLines("PrevResults.csv", records.Skip(1));
        }
    }
    public static string[] ReadRecords()
    {
        return File.ReadAllLines("PrevResults.csv");
    }
}
