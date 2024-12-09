namespace SwDc20.WebBlazor.Banners.Models;

public class BannersCharacterSkill
{
    public SkillStatics Name { get; set; }
    public int Value { get; set; }
    public AttributeStatics Attribute { get; set; }
	
    public BannersCharacterSkill(SkillStatics name, AttributeStatics attribute, int value = 0 )
    {
        Name = name;
        Attribute = attribute;
        Value = value;
    }
}