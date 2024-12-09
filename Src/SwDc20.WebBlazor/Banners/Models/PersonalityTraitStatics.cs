using Ardalis.SmartEnum;

namespace SwDc20.WebBlazor.Banners.Models;

public class PersonalityTraitStatics : SmartEnum<PersonalityTraitStatics>
{
	
    public static readonly PersonalityTraitStatics Amorous = new PersonalityTraitStatics(nameof(Amorous), 0);
    public static readonly PersonalityTraitStatics Chaste = new PersonalityTraitStatics(nameof(Chaste), 1);

    public static readonly PersonalityTraitStatics Forgiving = new PersonalityTraitStatics(nameof(Forgiving), 2);
    public static readonly PersonalityTraitStatics Vengeful = new PersonalityTraitStatics(nameof(Vengeful), 3);

    public static readonly PersonalityTraitStatics Generous = new PersonalityTraitStatics(nameof(Generous), 4);
    public static readonly PersonalityTraitStatics Selfish = new PersonalityTraitStatics(nameof(Selfish), 5);

    public static readonly PersonalityTraitStatics Honest = new PersonalityTraitStatics(nameof(Honest), 6);
    public static readonly PersonalityTraitStatics Deceitful = new PersonalityTraitStatics(nameof(Deceitful), 7);

    public static readonly PersonalityTraitStatics Just = new PersonalityTraitStatics(nameof(Just), 8);
    public static readonly PersonalityTraitStatics Arbitrary = new PersonalityTraitStatics(nameof(Arbitrary), 9);

    public static readonly PersonalityTraitStatics Merciful = new PersonalityTraitStatics(nameof(Merciful), 10);
    public static readonly PersonalityTraitStatics Cruel = new PersonalityTraitStatics(nameof(Cruel), 11);

    public static readonly PersonalityTraitStatics Modest = new PersonalityTraitStatics(nameof(Modest), 12);
    public static readonly PersonalityTraitStatics Proud = new PersonalityTraitStatics(nameof(Proud), 13);

    public static readonly PersonalityTraitStatics Prudent = new PersonalityTraitStatics(nameof(Prudent), 14);
    public static readonly PersonalityTraitStatics Reckless = new PersonalityTraitStatics(nameof(Reckless), 15);

    public static readonly PersonalityTraitStatics Temperate = new PersonalityTraitStatics(nameof(Temperate), 16);
    public static readonly PersonalityTraitStatics Indulgent = new PersonalityTraitStatics(nameof(Indulgent), 17);

    public static readonly PersonalityTraitStatics Trusting = new PersonalityTraitStatics(nameof(Trusting), 18);
    public static readonly PersonalityTraitStatics Suspicious = new PersonalityTraitStatics(nameof(Suspicious), 19);

    public PersonalityTraitStatics(string name, int value) : base(name,value)
    {		
    }
}