using System.ComponentModel.DataAnnotations;


namespace SwDc20.Core.Domain.Entities.Character.V0._8;

public class Character: BaseEntity
{
    public const string CurrentVersion = "v0.8";
    
    // General Information
    [Required]
    public string Name { get; set; }
    [Required]
    public string PlayerName { get; set; }
    
    public string ImageUrl { get; set; }
    
    [Range(0, 20)]
    public int Level { get; set; }
    public int CombatMastery => Math.Max((Level + 1) / 2, 1);

    // ✅Step 1: Attributes & Prime Modifier
    public int Might { get; set; }
    public int Agility { get; set; }
    public int Charisma { get; set; }
    public int Intelligence { get; set; }
    public int PrimeModifier => new[] { Might, Agility, Charisma, Intelligence }.Max();

    // ✅Step 2: Save Masteries
    public bool MightSaveMastery { get; set; }
    public bool AgilitySaveMastery { get; set; }
    public bool CharismaSaveMastery { get; set; }
    public bool IntelligenceSaveMastery { get; set; }

    // Step 3: Background
    public string Background { get; set; }
    public List<Skill> Skills { get; set; } = new();
    public List<Trade> Trades { get; set; } = new();
    public List<Language> Languages { get; set; } = new();

    // Step 4: Health Points
    public int MaxHitPoints { get; set; }
    public int CurrentHp { get; set; }
    public int TemporaryHp { get; set; }

    // Step 5: Stamina & Mana Points
    public int MaxStaminaPoints { get; set; }
    public int CurrentStamina { get; set; }
    public int MaxManaPoints { get; set; }
    public int CurrentManaPoints { get; set; }

    // Step 6: Defense
    public int PhysicalDefense { get; set; }
    public int MysticalDefense { get; set; }
    public int PhysicalDamageReduction { get; set; }
    public int MysticalDamageReduction { get; set; }

    // Step 7: Combat Modifiers
    public int AttackSpellCheck { get; set; }
    public int SaveDifficultyCheck { get; set; }
    public int MartialCheck { get; set; }
    public int DeathThreshold { get; set; }
    public int MoveSpeed { get; set; }
    public int JumpDistance { get; set; }
    public int RestPoints { get; set; }
    public int CurrentRestPoints { get; set; }
    public int GritPoints { get; set; }
    public int CurrentGritPoints { get; set; }

    // Step 8: Ancestry
    public List<AncestryOption> AncestryOptions { get; set; } = new List<AncestryOption>();
    public string Ancestry { get; set; }
    public List<string> AncestryTraits { get; set; } = new List<string>();

    // Step 9: Class
    public string Class { get; set; }
    public string Subclass { get; set; }
    public List<CharacterFeature> Features { get; set; } = new List<CharacterFeature>();

    // Step 10: Weapons & Inventory
    public List<CharacterInventory> Inventory { get; set; } = new List<CharacterInventory>();
    public List<CharacterWeapon> Weapons { get; set; } = new List<CharacterWeapon>();

    // Additional properties
    public int ActionPoints { get; set; }
    public int CurrentActionPoints { get; set; }
    
    public List<CharacterAttack> Attacks { get; set; } = new List<CharacterAttack>();
    public List<CharacterResource> Resources { get; set; } = new List<CharacterResource>();
    public int Currency { get; set; }

    public bool IsInitiallySaved { get; set; }
    public DateTime CreatedTimestamp { get; set; }
    public string SelectedDeathThresholdAttribute { get; set; } = "Prime";
    public string SelectedRestPointsAttribute { get; set; } = nameof(Might);
    public string SelectedGritPointsAttribute { get; set; } = nameof(Charisma);
    public string SelectedMartialCheckOption { get; set; } = string.Empty;
    public List<CharacterCondition> CharacterConditions { get; set; } = new List<CharacterCondition>();
    
    public Character()
    {
        Id = Guid.NewGuid();
        Version = CurrentVersion;
    }
    
    public int GetSkillValue(string skillName)
    {
        var skill = Skills.FirstOrDefault(s => s.Name == skillName);
        return skill?.CalculateValue(this) ?? 0;
    }

    public static class CalculateSaves
    {
        public static int CalculateMightSave(Character character)
        {
            var save = character.Might;
            if (character.MightSaveMastery)
            {
                save += character.CombatMastery; 
            }
            return save;
        }
        
        public static int CalculateAgilitySave(Character character)
        {
            var save = character.Agility;
            if (character.AgilitySaveMastery)
            {
                save += character.CombatMastery; 
            }
            return save;
        }
        
        public static int CalculateCharismaSave(Character character)
        {
            var save = character.Charisma;
            if (character.CharismaSaveMastery)
            {
                save += character.CombatMastery; 
            }
            return save;
        }
        
        public static int CalculateIntelligenceSave(Character character)
        {
            var save = character.Intelligence;
            if (character.IntelligenceSaveMastery)
            {
                save += character.CombatMastery; 
            }
            return save;
        }
    }
}

public class CharacterCondition
{
	public string Name { get; set; }
	public string Description { get; set; }
	public string HelperDescription { get; set; }
	
	public int Duration { get; set; } = -1;
	public int? RemainingDuration { get; set; }
		
	public int StackCount { get; set; }
	public int StackMax { get; set; } = 1;
	public List<Variable.V0._8.Variable> PerStackVariables { get; set; } = new ();
	public List<HealCondition> PerStackHealConditions { get; set; } = new ();
	public List<HealCondition> MaxStackHealConditions { get; set; } = new ();
	

	public List<HealConditionKeyed> HealConditions { get; set; } = new();
	public List<ConditionalKeyed> ConditionVariables { get; set; } = new();
	
	public List<CharacterCondition> SubConditions { get; set; } = new List<CharacterCondition>();
	public List<CharacterCondition> TransformationConditions { get; set; } = new List<CharacterCondition>();


	public void AddStackCount() 
	{
		if(StackCount == StackMax)
		{
			return;
		}
		
		StackCount++;
		
		if(PerStackVariables.Any())
		{
			ConditionVariables.AddRange(PerStackVariables.Select(aspsv => new ConditionalKeyed(StackCount, aspsv)));
		}

		if (PerStackHealConditions.Any())
		{
			HealConditions.AddRange(PerStackHealConditions.Select(aspsv => new HealConditionKeyed(StackCount, aspsv)));
		}

		if(StackCount == StackMax && MaxStackHealConditions.Any())
		{
			HealConditions.AddRange(MaxStackHealConditions.Select(hc => new HealConditionKeyed(StackCount,hc)));
		}
	}

	public void RemoveStackCount(int? stackCount = null)
	{
		if(StackCount == 0)
		{
			return;
		}
		
		if (PerStackVariables.Any())
		{
			ConditionVariables.RemoveAll(cv => cv.Key == StackCount);
		}

		if (PerStackHealConditions.Any())
		{
			HealConditions.RemoveAll(t => t.Key == StackCount);
		}
		
		if (StackCount == StackMax && MaxStackHealConditions.Any())
		{
			HealConditions.RemoveAll(t => t.Key == StackCount);
		}
		StackCount--;		
	}
	
	public string GetName() => StackCount > 0 && StackMax > 1 ? $"{Name} {StackCount}" : Name;

	public void ResetStackCount()
	{ 
		StackCount = 0;
		ConditionVariables.RemoveAll(cv => cv.Key > 0);
		HealConditions.RemoveAll(cv => cv.Key > 0);
	}
	
	public void SetStackMax(int max) => StackMax = max;
}

public record ConditionalKeyed(int Key, Variable.V0._8.Variable Variable);
public record HealConditionKeyed(int Key, HealCondition HealCondition);

public class HealCondition
{
	public string Name { get; set; }
	public string Description { get; set; }
	// public int Duration { get; set; }
	// public int RemainingDuration { get; set; }

	public HealCondition() { }
	public HealCondition(string name, string description)
	{
		Name = name;
		Description = description;
	}

	public HealCondition AppendedDescription(string additionalDescription) =>
		new HealCondition(Name, $"{Description} {additionalDescription}");

	public HealCondition PrependedDescription(string additionalDescription) =>
		new HealCondition(Name, $"{additionalDescription} {Description}");

	public HealCondition WithName(string name) => new HealCondition(name, Description);
}