using Ardalis.SmartEnum;

namespace SwDc20.WebBlazor.Banners.Models;

public class DivineFavorStatics : SmartEnum<DivineFavorStatics>
{
    public static readonly DivineFavorStatics Indebted = new DivineFavorStatics(nameof(Indebted),0);
    public static readonly DivineFavorStatics GoodStanding = new DivineFavorStatics(nameof(GoodStanding),1);
    public static readonly DivineFavorStatics Favored = new DivineFavorStatics(nameof(Favored),2);
	
    public DivineFavorStatics(string name, int value) : base(name,value)
    {
    }
}