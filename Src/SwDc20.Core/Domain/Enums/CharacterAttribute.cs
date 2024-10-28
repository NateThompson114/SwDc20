using Ardalis.SmartEnum;

namespace SwDc20.Core.Domain.Enums;

public class CharacterAttribute : SmartEnum<CharacterAttribute>
{
    public static readonly CharacterAttribute Prime = new(nameof(Prime), 0);
    public static readonly CharacterAttribute Might = new(nameof(Might), 1);
    public static readonly CharacterAttribute Agility = new(nameof(Agility), 2);
    public static readonly CharacterAttribute Charisma = new(nameof(Charisma), 3);
    public static readonly CharacterAttribute Intelligence = new(nameof(Intelligence), 4);
    
    
    public CharacterAttribute(string name, int value) : base(name, value)
    {
    }
    
    public static CharacterAttribute FromName(string name)
    {
        return FromName(name, true);
    }
    
    public static List<CharacterAttribute> GetAttributes()
    {
        return new List<CharacterAttribute>
        {
            Prime, Might, Agility, Charisma, Intelligence 
        };
    }
}