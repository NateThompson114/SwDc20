namespace SwDc20.Core.Domain.Entities;

public class CalculationResult
{
    public Variable.V0._8.Variable? Variable { get; set; }
    public double Value { get; set; }
    public string ExpandedCalculation { get; set; }
}