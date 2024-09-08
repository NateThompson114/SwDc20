using System.ComponentModel.DataAnnotations;

namespace SwDc20.WebBlazor.Models.Character.V0._08;

public class Character
{
    public const string CurrentVersion = "v0.8";

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Version { get; set; } = CurrentVersion;
    
    // General Information
    [Required]
    public string Name { get; set; }
    [Required]
    public string PlayerName { get; set; }
    
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
    public List<Skill> Skills { get; set; }
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

    

    // Additional properties
    public int ActionPoints { get; set; }
    public List<string> Attacks { get; set; } = new List<string>();
    public int Currency { get; set; }

    public Character()
    {
        Id = Guid.NewGuid();
        Version = CurrentVersion;
        Skills = SkillsStatics.DefaultSkills.Select(s => new Skill(s.Name, s.AttributeUsed, s.Tag)).ToList();
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

public static class SkillsStatics
{
    public static readonly Skill Awareness = new Skill("Awareness", "Prime");
    public static readonly Skill Athletics = new Skill("Athletics", "Might");
    public static readonly Skill Intimidation = new Skill("Intimidation", "Might");
    public static readonly Skill Acrobatics = new Skill("Acrobatics", "Agility");
    public static readonly Skill Trickery = new Skill("Trickery", "Agility");
    public static readonly Skill Stealth = new Skill("Stealth", "Agility");
    public static readonly Skill AnimalHandling = new Skill("Animal Handling", "Charisma");
    public static readonly Skill Influence = new Skill("Influence", "Charisma");
    public static readonly Skill Insight = new Skill("Insight", "Charisma");
    public static readonly Skill Investigation = new Skill("Investigation", "Intelligence");
    public static readonly Skill Medicine = new Skill("Medicine", "Intelligence");
    public static readonly Skill Survival = new Skill("Survival", "Intelligence");
    public static readonly Skill Arcana = new Skill("Arcana", "Intelligence", "Knowledge");
    public static readonly Skill History = new Skill("History", "Intelligence", "Knowledge");
    public static readonly Skill Nature = new Skill("Nature", "Intelligence", "Knowledge");
    public static readonly Skill Occultism = new Skill("Occultism", "Intelligence", "Knowledge");
    public static readonly Skill Religion = new Skill("Religion", "Intelligence", "Knowledge");
    

    public static List<Skill> DefaultSkills => new List<Skill>
    {
        Awareness, Athletics, Intimidation, Acrobatics, Trickery, Stealth,
        AnimalHandling, Influence, Insight, Investigation, Medicine, Survival, Arcana, History, Nature, Occultism, Religion
    };
    
    public static List<string> AttributeOptions => new List<string>
    {
        "Prime", "Might", "Agility", "Charisma", "Intelligence"
    };
}

public class Trade
{
    public string Name { get; set; }
    public int Bonus { get; set; }
}

public class Skill
{
    public string Name { get; set; }
    public string AttributeUsed { get; set; }
    public int Rank { get; set; }
    
    public string? Tag { get; set; }

    public Skill(string name, string attributeUsed, string? tag = null)
    {
        Name = name;
        AttributeUsed = attributeUsed;
        Rank = 0;
        Tag = tag;
    }

    public int CalculateValue(Character character)
    {
        int attributeValue = GetAttributeValue(character);
        return attributeValue + (Rank * 2);
    }

    private int GetAttributeValue(Character character)
    {
        return AttributeUsed switch
        {
            "Prime" => character.PrimeModifier,
            "Might" => character.Might,
            "Agility" => character.Agility,
            "Charisma" => character.Charisma,
            "Intelligence" => character.Intelligence,
            _ => 0
        };
    }
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