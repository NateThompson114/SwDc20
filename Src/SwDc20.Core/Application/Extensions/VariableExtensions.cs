using SwDc20.Core.Domain.Entities.Variable.V0._8;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Application.Extensions;

public static class VariableExtensions
{
    public static string GetStringVariable(this Variable variable) => variable.Calculation ?? $"{{{variable.Name}}}";
    
    // public static double EvaluateCalculation(this Variable variable)
    // {
    //     if(string.IsNullOrWhiteSpace(variable.Calculation))
    //     {
    //         return variable.Value;
    //     }
    //     
    //     // var evaluator = new CalculationService();
    //     //
    //     // return evaluator.Calculate(variable);
    // }
    
    public static void AddProperties(this Variable variable, params Property[] properties)
    {
        if(variable.Properties == null)
        {
            variable.Properties = new();
        }
        
        variable.Properties.AddRange(properties);
    }
}