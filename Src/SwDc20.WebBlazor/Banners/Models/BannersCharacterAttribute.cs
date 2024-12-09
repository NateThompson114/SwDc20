namespace SwDc20.WebBlazor.Banners.Models;

public class BannersCharacterAttribute
{
    public AttributeStatics Name { get; set; }
    public string ShortName { get; set; }
    public int Value { get; set; }
	
    public BannersCharacterAttribute(AttributeStatics name, int value = 0)
    {
        Name = name;
        ShortName = name.Name.ToUpper().Substring(0, 3);
        Value = value;
    }
}