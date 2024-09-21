using Ardalis.SmartEnum;

namespace SwDc20.Core.Domain.Enums;

public class Property : SmartEnum<Property>
{
    public static readonly Property Melee = new(nameof(Melee), 1);
    public static readonly Property Ranged = new(nameof(Ranged), 2);
    public static readonly Property Magic = new(nameof(Magic), 3);
            
    public Property(string name, int value) : base(name, value) { }
}