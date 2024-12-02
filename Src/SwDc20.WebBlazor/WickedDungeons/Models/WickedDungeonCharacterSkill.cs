namespace SwDc20.WebBlazor.WickedDungeons.Models;

public class WickedDungeonCharacterSkill
{
    public SkillStatics Name { get; set; }
    public int Value { get; set; }
    public AttributeStatics Attribute { get; set; }
	
    public WickedDungeonCharacterSkill(SkillStatics name, AttributeStatics attribute, int value = 0 )
    {
        Name = name;
        Attribute = attribute;
        Value = value;
    }
}