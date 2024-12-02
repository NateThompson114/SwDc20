namespace SwDc20.WebBlazor.WickedDungeons.Models;

public class WickedDungeonCharacterPassion
{
    public int Value { get; set; }
    public string Name { get; set; }
	
    public WickedDungeonCharacterPassion(string name, int value)
    {
        Name = name;
        Value = value;
    }
}