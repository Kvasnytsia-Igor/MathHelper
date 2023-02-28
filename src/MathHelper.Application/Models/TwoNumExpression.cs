using MathHelper.Application.Enums;

namespace MathHelper.Application.Models;

public class TwoNumExpression
{
    public decimal? NumberA { get; set; }
    public decimal NumberB { get; set; }
    public ArithmeticOperation ArithmeticOperation { get; set; }
    public decimal Result { get; set; }
    public bool IsCompleted { get; set; }
}
