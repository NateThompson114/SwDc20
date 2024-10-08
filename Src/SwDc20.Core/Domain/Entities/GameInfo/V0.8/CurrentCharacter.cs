using SwDc20.Core.Domain.Entities.Character.V0._8;

namespace SwDc20.Core.Domain.Entities.GameInfo.V0._8;

public class CurrentCharacter
{
    public CurrentCharacter(Character.V0._8.Character character)
    {
        Character = character;
        CurrentStamina = character.MaxStaminaPoints;
        CurrentManaPoints = character.MaxManaPoints;
        CurrentHp = character.MaxHitPoints;
        TemporaryHp = 0;
        CurrentActionPoints = 0;
        CurrentExhaustion = 0;
        CurrentRestPoints = character.RestPoints;
        CurrentGritPoints = character.GritPoints;
        CurrentResources = character.Resources?.Select(cr => new CurrentCharacterResource(0, cr)).ToList() ?? new List<CurrentCharacterResource>();
        CharacterInventory = character.Inventory;
    }

    public Character.V0._8.Character Character { get; set; }
    public bool DefaultCurrentCharacter { get; set; }
    public int CurrentStamina { get; set; }
    public int CurrentManaPoints { get; set; }
    
    public int CurrentHp { get; set; }
    public int TemporaryHp { get; set; }

    public int CurrentActionPoints { get; set; }
    public int CurrentExhaustion { get; set; }
    
    public int CurrentRestPoints { get; set; }
    public int CurrentGritPoints { get; set; }
    
    public List<CurrentCharacterResource> CurrentResources { get; set; }
    public List<CharacterInventory> CharacterInventory { get; set; }
    
    public List<CurrentCharacterCondition> CurrentConditions { get; set; } = new List<CurrentCharacterCondition>();
}

public class CurrentCharacterCondition
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
	

	public List<HealConditioKeyed> HealConditions { get; set; } = new();
	public List<ConditionalKeyed> ConditionVariables { get; set; } = new();
	
	public List<CurrentCharacterCondition> SubConditions { get; set; } = new List<CurrentCharacterCondition>();
	public List<CurrentCharacterCondition> TransformationConditions { get; set; } = new List<CurrentCharacterCondition>();


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
			HealConditions.AddRange(PerStackHealConditions.Select(aspsv => new HealConditioKeyed(StackCount, aspsv)));
		}

		if(StackCount == StackMax && MaxStackHealConditions.Any())
		{
			HealConditions.AddRange(MaxStackHealConditions.Select(hc => new HealConditioKeyed(StackCount,hc)));
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
public record HealConditioKeyed(int Key, HealCondition HealCondition);

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