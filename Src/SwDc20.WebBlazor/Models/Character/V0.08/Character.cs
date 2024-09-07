namespace SwDc20.WebBlazor.Models.Character.V0._08;

public class Character
{
    public const string CurrentVersion = "v0.8";

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Version { get; set; } = CurrentVersion;

    // Step 1: Attributes & Prime Modifier
    public int Might { get; set; }
    public int Agility { get; set; }
    public int Charisma { get; set; }
    public int Intelligence { get; set; }
    public int PrimeModifier => new[] { Might, Agility, Charisma, Intelligence }.Max();

    // Step 2: Save Masteries
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
    public int MaxHP { get; set; }

    // Step 5: Stamina & Mana Points
    public int MaxSP { get; set; }
    public int MaxMP { get; set; }

    // Step 6: Defense
    public int PhysicalDefense { get; set; }
    public int MysticalDefense { get; set; }
    public int PhysicalDamageReduction { get; set; }
    public int MysticalDamageReduction { get; set; }

    // Step 7: Combat Modifiers
    public int AttackSpellCheck { get; set; }
    public int SaveDC { get; set; }
    public int MartialCheck { get; set; }
    public int DeathThreshold { get; set; }
    public int MoveSpeed { get; set; }
    public int JumpDistance { get; set; }
    public int RestPoints { get; set; }
    public int GritPoints { get; set; }

    // Step 8: Ancestry
    public string Ancestry { get; set; }
    public List<string> AncestryTraits { get; set; } = new List<string>();

    // Step 9: Class
    public string Class { get; set; }
    public string Subclass { get; set; }
    public List<string> ClassFeatures { get; set; } = new List<string>();

    // Step 10: Weapons & Inventory
    public List<string> Equipment { get; set; } = new List<string>();
    public List<Weapon> Weapons { get; set; } = new List<Weapon>();

    // General Information
    public string Name { get; set; }
    public int Level { get; set; }
    public int CombatMastery { get; set; }

    // Additional properties
    public int ActionPoints { get; set; }
    public List<string> Attacks { get; set; } = new List<string>();
    public int Currency { get; set; }

    public Character()
    {
        Id = Guid.NewGuid();
        Version = CurrentVersion;
    }

    //todo: Example of calculating might, need this for all the other calculations so we can have auto help and calculations
    public int CalculateMightSave(Character character)
    {
        int save = character.Might;
        if (character.MightSaveMastery)
        {
            save += character.CombatMastery; // Assuming you have a CombatMastery property
        }
        return save;
    }
}

public class Trade
{
    public string Name { get; set; }
    public int Bonus { get; set; }
}

public class Skill
{
    public string Name { get; set; }
    public int Bonus { get; set; }
}

public class Language
{
    public string Name { get; set; }
    public string Proficiency { get; set; } // e.g., "Fluent", "Limited"
}

public class Weapon
{
    public string Name { get; set; }
    public string Damage { get; set; }
    public string DamageType { get; set; }
    public string Description { get; set; }
    public string Calculation { get; set; } // Placeholder for script
}