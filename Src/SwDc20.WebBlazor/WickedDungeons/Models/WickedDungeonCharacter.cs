namespace SwDc20.WebBlazor.WickedDungeons.Models;

public class WickedDungeonCharacter
{
	public string Name { get; set; }
	public string Banner { get; set; }
	public int Age { get; set; }
	public string Homeland { get; set; }
	public string Role { get; set; }
	public string Caste { get; set; }
	public string PictureUrl { get; set; }

	public List<WickedDungeonCharacterAttribute> Attributes { get; set; } = new();
	public List<WickedDungeonCharacterSkill> Skills { get; set; } = new();

	public string DivineFavor { get; set; }

	public List<WickedDungeonCharacterStat> Stats { get; set; } = new();

	public List<WickedDungeonCharacterPersonalityTrait> PersonalityTraits { get; set;} = new();

	public List<WickedDungeonCharacterPassion> Passions { get; set; } = new();
	
	public List<WickedDungeonCharacterGear> Gear { get; set; } = new();
	
	public string Gift { get; set; }

	public WickedDungeonCharacter()
	{
		PersonalityTraits = new List<WickedDungeonCharacterPersonalityTrait>()
		{
			new(PersonalityTraitStatics.Amorous, 1),	
			new(PersonalityTraitStatics.Chaste,1,true),
			new(PersonalityTraitStatics.Forgiving,2),
			new(PersonalityTraitStatics.Vengeful,2,true),
			new(PersonalityTraitStatics.Generous,3),
			new(PersonalityTraitStatics.Selfish,3,true),
			new(PersonalityTraitStatics.Honest,4),
			new(PersonalityTraitStatics.Deceitful,4,true),
			new(PersonalityTraitStatics.Just,5),
			new(PersonalityTraitStatics.Arbitrary,5,true),
			new(PersonalityTraitStatics.Merciful,6),
			new(PersonalityTraitStatics.Cruel,6,true),
			new(PersonalityTraitStatics.Modest,7),
			new(PersonalityTraitStatics.Proud,7,true),
			new(PersonalityTraitStatics.Prudent,8),
			new(PersonalityTraitStatics.Reckless,8,true),
			new(PersonalityTraitStatics.Temperate,9),
			new(PersonalityTraitStatics.Indulgent,9,true),
			new(PersonalityTraitStatics.Trusting,10),
			new(PersonalityTraitStatics.Suspicious,10,true)
		};

		Skills = new List<WickedDungeonCharacterSkill>()
		{
			new(SkillStatics.Awareness, AttributeStatics.Wisdom),
			new(SkillStatics.Battle, AttributeStatics.Guile),
			new(SkillStatics.Brawling, AttributeStatics.Strength),
			new(SkillStatics.Courtesy, AttributeStatics.Appeal),
			new(SkillStatics.Craft, AttributeStatics.Appeal),
			new(SkillStatics.Deception, AttributeStatics.Guile),
			new(SkillStatics.Folklore, AttributeStatics.Wisdom),
			new(SkillStatics.Healing, AttributeStatics.Wisdom),
			new(SkillStatics.Hunting, AttributeStatics.Wisdom),
			new(SkillStatics.Intrigue, AttributeStatics.Guile),
			new(SkillStatics.Literacy, AttributeStatics.Wisdom),
			new(SkillStatics.Orate, AttributeStatics.Appeal),
			new(SkillStatics.Perform, AttributeStatics.Appeal),
			new(SkillStatics.Recognize, AttributeStatics.Wisdom),
			new(SkillStatics.Religion, AttributeStatics.Wisdom),
			new(SkillStatics.Riding, AttributeStatics.Strength),
			new(SkillStatics.Romance, AttributeStatics.Appeal),
			new(SkillStatics.Stealth, AttributeStatics.Guile),
			new(SkillStatics.Stewardship, AttributeStatics.Wisdom),
			new(SkillStatics.Weaponry, AttributeStatics.Dexterity),
			new(SkillStatics.Weaponry, AttributeStatics.Strength)
		};
	}
	
	public void CalculateStats()
	{
		Stats.Clear();
		
		Stats.AddRange(new List<WickedDungeonCharacterStat>
		{
			new(StatStatics.Defense, RoundUp(GetAttributeValue(AttributeStatics.Dexterity) / 2)),
			new(StatStatics.Damage, RoundUp(GetAttributeValue(AttributeStatics.Strength) / 2)),
			new(StatStatics.HealingRate, RoundUp(GetAttributeValue(AttributeStatics.Constitution) / 2)),
			new(StatStatics.HitPoints, RoundUp(GetAttributeValue(AttributeStatics.Constitution) * 2)),
			new(StatStatics.MajorWound, (int)GetAttributeValue(AttributeStatics.Constitution)),
			new(StatStatics.MoveRate, (int)GetAttributeValue(AttributeStatics.Dexterity))
		});		
	}
	
	public double GetAttributeValue(AttributeStatics attribute)
	{
		return (double)Attributes.First(a => a.Name == attribute).Value;
	}
	
	private static int RoundUp(double value)
	{
		return (int)Math.Round(value, MidpointRounding.AwayFromZero);
	}
	
	public List<WickedDungeonCharacterPersonalityTrait> SetPersonalityTrait(PersonalityTraitStatics trait, int value)
	{
		var traitObject = PersonalityTraits.First(pt => pt.Trait == trait);
		var pairedTrait = PersonalityTraits.First(pt => 
			pt.Group == traitObject.Group && 
			pt.NegativeTrait == !traitObject.NegativeTrait
		);
		var traits = new List<WickedDungeonCharacterPersonalityTrait>() { traitObject, pairedTrait};;
		if(value > 20 || value < 0)
		{
			return traits;
		}
		
		traitObject.Value = value;
		pairedTrait.Value = 20 - value;
		
		return traits;
	}
	
	public List<WickedDungeonCharacterPersonalityTrait> IncreasePersonalityTrait(PersonalityTraitStatics trait) 
	{
		var traitObject = PersonalityTraits.First(pt => pt.Trait == trait);
		return SetPersonalityTrait(trait, traitObject.Value + 1);
	}
	
	public WickedDungeonCharacterPassion AddPassion(string name, int value)
	{
		if(Passions.Any(p => p.Name == name))
		{
			var existingPassion = Passions.First(p => p.Name == name);
			existingPassion.Value = value;
			return existingPassion;
		}
		
		var newPassion = new WickedDungeonCharacterPassion(name,value);
		Passions.Add(newPassion);
		return newPassion;
	}
	
	public void RemovePassion(string name)
	{
		var existingPassion = Passions.FirstOrDefault(p => p.Name == name);
		Passions.Remove(existingPassion);
	}

	public WickedDungeonCharacterGear AddGear(string name, string description = null, bool isFineQuality = false)
	{
		if (Passions.Any(p => p.Name == name))
		{
			var existingGear = Gear.First(p => p.Name == name);
			existingGear.Description = description;
			existingGear.IsFineQuality = isFineQuality;
			
			return existingGear;
		}

		var newGear = new WickedDungeonCharacterGear(name, description, isFineQuality);
		Gear.Add(newGear);
		return newGear;
	}

	public void RemoveGear(string name)
	{
		var existingGear = Gear.FirstOrDefault(p => p.Name == name);
		Gear.Remove(existingGear);
	}
}