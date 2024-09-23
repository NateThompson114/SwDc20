using Ardalis.SmartEnum;

namespace SwDc20.Core.Domain.Enums;

public class Attribute : SmartEnum<Attribute>
{
    public static readonly Attribute Might = new(nameof(Might), 1);
    public static readonly Attribute Agility = new(nameof(Agility), 2);
    public static readonly Attribute Charisma = new(nameof(Charisma), 3);
    public static readonly Attribute Intelligence = new(nameof(Intelligence), 4);
    public static readonly Attribute Prime = new(nameof(Prime), 5);
    
    public Attribute(string name, int value) : base(name, value)
    {
    }
    
    public static List<Attribute> GetAttributes()
    {
        return new List<Attribute>
        {
            Might, Agility, Charisma, Intelligence, Prime
        };
    }
}