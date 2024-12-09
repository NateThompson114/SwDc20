namespace SwDc20.WebBlazor.Banners.Models;

public class BannersCharacterPersonalityTrait
{
    public PersonalityTraitStatics Trait { get; set; }
    public int Value { get; set; }
    public bool Used { get; set; }
    public bool NegativeTrait { get; set; }
    public int Group { get; set; }
	
    public BannersCharacterPersonalityTrait(
        PersonalityTraitStatics trait,
        int group,
        bool negativeTrait = false,
        int value = 10
    )
    {
        Trait = trait;
        Group = group;
        NegativeTrait = negativeTrait;
        Value = value;
    }
}