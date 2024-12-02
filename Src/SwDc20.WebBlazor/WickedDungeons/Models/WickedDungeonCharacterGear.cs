namespace SwDc20.WebBlazor.WickedDungeons.Models;

public class WickedDungeonCharacterGear
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsFineQuality { get; set; }
	
    public WickedDungeonCharacterGear(string name, string description = null, bool isFineQuality = false)
    {
        Name = name;
        Description = description;
        IsFineQuality = isFineQuality;
    }
}