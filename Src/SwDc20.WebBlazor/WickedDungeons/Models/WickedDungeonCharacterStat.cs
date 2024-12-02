namespace SwDc20.WebBlazor.WickedDungeons.Models;

public class WickedDungeonCharacterStat
{
    public StatStatics Name { get; set; }
    public int Value { get; set; }
	
    public WickedDungeonCharacterStat(StatStatics name, int value = 0)
    {
        Name = name;
        Value = value;
    }
}