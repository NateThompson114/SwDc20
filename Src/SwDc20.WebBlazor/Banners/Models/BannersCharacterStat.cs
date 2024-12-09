namespace SwDc20.WebBlazor.Banners.Models;

public class BannersCharacterStat
{
    public StatStatics Name { get; set; }
    public int Value { get; set; }
	
    public BannersCharacterStat(StatStatics name, int value = 0)
    {
        Name = name;
        Value = value;
    }
}