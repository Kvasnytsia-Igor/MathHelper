using System.Linq.Expressions;

namespace MathHelper.Application.Models;

public class Calculation
{
    public Calculation? LeftHandValue { get; set; }
    public Calculation? RightHandValue { get; set; }
    public decimal? CurrentValue { get; set; }
    public Func<decimal, decimal, decimal>? Function { get; set; }
    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
