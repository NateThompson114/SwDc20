using Ardalis.SmartEnum;

namespace SwDc20.WebBlazor.Banners.Models;

public class AttributeStatics : SmartEnum<AttributeStatics>
{
    public static readonly AttributeStatics Appeal = new AttributeStatics(nameof(Appeal),0);
    public static readonly AttributeStatics Constitution = new AttributeStatics(nameof(Constitution),1);
    public static readonly AttributeStatics Dexterity = new AttributeStatics(nameof(Dexterity),2);
    public static readonly AttributeStatics Guile = new AttributeStatics(nameof(Guile),3);
    public static readonly AttributeStatics Strength = new AttributeStatics(nameof(Strength),4);
    public static readonly AttributeStatics Wisdom = new AttributeStatics(nameof(Wisdom),5);

    public AttributeStatics(string name, int value) : base(name, value)
    {
    }
}