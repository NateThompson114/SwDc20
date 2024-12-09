namespace SwDc20.WebBlazor.Banners.Models;

public class BannersCharacterGear
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsFineQuality { get; set; }
	
    public BannersCharacterGear(string name, string description = null, bool isFineQuality = false)
    {
        Name = name;
        Description = description;
        IsFineQuality = isFineQuality;
    }
}