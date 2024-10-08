using Ardalis.SmartEnum;

namespace SwDc20.Core.Domain.Enums;

public class VariableProperty(string name, int value) : SmartEnum<VariableProperty>(name, value)
{
    public static readonly VariableProperty None = new(nameof(None), 0);
    
    public static readonly VariableProperty Melee = new(nameof(Melee), 1);
    public static readonly VariableProperty Ranged = new(nameof(Ranged), 2);
    public static readonly VariableProperty Magic = new(nameof(Magic), 3);
    
    public static readonly VariableProperty Ancestry = new(nameof(Ancestry), 1000);
    public static readonly VariableProperty Condition = new(nameof(Condition), 2000);

    public static List<VariableProperty> ToList()
    {
        return typeof(VariableProperty)
            .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
            .Where(f => f.FieldType == typeof(VariableProperty))
            .Select(f => (VariableProperty)f.GetValue(null))
            .ToList();
    }
}

// public static class VariableProperty
// {
//     public const string Melee =  nameof(Melee);
//     public const string Ranged = nameof(Ranged);
//     public const string Magic =  nameof(Magic);
// }