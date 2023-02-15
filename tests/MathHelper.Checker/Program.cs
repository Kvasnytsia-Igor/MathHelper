using MathHelper.TextInterface.Controllers;
using System.Globalization;
using System.Text.RegularExpressions;

CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
string exp = "1000000000*1000000000";
string res = CalculatorController.Calculate(exp);
Console.WriteLine(res);