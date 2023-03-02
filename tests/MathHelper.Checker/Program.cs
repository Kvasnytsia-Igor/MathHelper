using MathHelper.TextInterface;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

string[] rec =
{
    "11;2",
    "1;2",
    "1;2",
    "1;2",
    "1;2",
    "1;2",
};

Console.WriteLine(Viewer.CSVRecordsView(rec));


