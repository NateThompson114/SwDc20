namespace SwDc20.WebBlazor.Banners.Models;

public class BannersCharacterPassion
{
    public int Value { get; set; }
    public string Name { get; set; }
	
    public BannersCharacterPassion(string name, int value)
    {
        Name = name;
        Value = value;
    }
}