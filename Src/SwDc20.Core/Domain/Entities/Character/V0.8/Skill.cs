namespace SwDc20.Core.Domain.Entities.Character.V0._8;

public class Skill: BaseEntity
{
    public const string CurrentVersion = "0.8";
    public string Name { get; set; }
    public string AttributeUsed { get; set; }
    public int Rank { get; set; }
    
    public string? Tag { get; set; }

    public Skill(string name, string attributeUsed, string? tag = null, Guid? id = default)
    {
        Id = id ?? Guid.NewGuid();
        Version = CurrentVersion;
        Name = name;
        AttributeUsed = attributeUsed;
        Rank = 0;
        Tag = tag;
    }

    public Skill()
    {
        Id = Guid.NewGuid();
        Version = CurrentVersion;
    }

    public int CalculateValue(Character character)
    {
        int attributeValue = GetAttributeValue(character);
        return attributeValue + (Rank * 2);
    }

    private int GetAttributeValue(Character character)
    {
        return AttributeUsed switch
        {
            "Prime" => character.PrimeModifier,
            "Might" => character.Might,
            "Agility" => character.Agility,
            "Charisma" => character.Charisma,
            "Intelligence" => character.Intelligence,
            _ => 0
        };
    }
}