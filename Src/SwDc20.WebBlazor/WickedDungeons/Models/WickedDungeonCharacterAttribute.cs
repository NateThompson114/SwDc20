namespace SwDc20.WebBlazor.WickedDungeons.Models;

public class WickedDungeonCharacterAttribute
{
    public AttributeStatics Name { get; set; }
    public string ShortName { get; set; }
    public int Value { get; set; }
	
    public WickedDungeonCharacterAttribute(AttributeStatics name, int value = 0)
    {
        Name = name;
        ShortName = name.Name.ToUpper().Substring(0, 3);
        Value = value;
    }
}