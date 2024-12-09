using Ardalis.SmartEnum;

namespace SwDc20.WebBlazor.Banners.Models;

public class SkillStatics : SmartEnum<SkillStatics>
{
    public static readonly SkillStatics Awareness = new SkillStatics(nameof(Awareness),0);
    public static readonly SkillStatics Battle = new SkillStatics(nameof(Battle),1);
    public static readonly SkillStatics Brawling = new SkillStatics(nameof(Brawling),2);
    public static readonly SkillStatics Courtesy = new SkillStatics(nameof(Courtesy),3);
    public static readonly SkillStatics Craft = new SkillStatics(nameof(Craft),4);
    public static readonly SkillStatics Deception = new SkillStatics(nameof(Deception),5);
    public static readonly SkillStatics Folklore = new SkillStatics(nameof(Folklore),6);
    public static readonly SkillStatics Healing = new SkillStatics(nameof(Healing),7);
    public static readonly SkillStatics Hunting = new SkillStatics(nameof(Hunting),8);
    public static readonly SkillStatics Intrigue = new SkillStatics(nameof(Intrigue),9);
    public static readonly SkillStatics Literacy = new SkillStatics(nameof(Literacy),10);
    public static readonly SkillStatics Orate = new SkillStatics(nameof(Orate),11);
    public static readonly SkillStatics Perform = new SkillStatics(nameof(Perform),12);
    public static readonly SkillStatics Recognize = new SkillStatics(nameof(Recognize),13);
    public static readonly SkillStatics Religion = new SkillStatics(nameof(Religion),14);
    public static readonly SkillStatics Riding = new SkillStatics(nameof(Riding),15);
    public static readonly SkillStatics Romance = new SkillStatics(nameof(Romance),16);
    public static readonly SkillStatics Stealth = new SkillStatics(nameof(Stealth),17);
    public static readonly SkillStatics Stewardship = new SkillStatics(nameof(Stewardship),18);
    public static readonly SkillStatics Weaponry = new SkillStatics(nameof(Weaponry),19);

    public SkillStatics(string name, int value) : base(name,value)
    {
    }
}