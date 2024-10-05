using System.ComponentModel.DataAnnotations;
using SwDc20.Core.Application.Constants;

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

    // Step 5: Stamina & Mana Points
    public int MaxStaminaPoints { get; set; }
    public int MaxManaPoints { get; set; }

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
    public int GritPoints { get; set; }

    // Step 8: Ancestry
    public string Ancestry { get; set; }
    public List<string> AncestryTraits { get; set; } = new List<string>();

    // Step 9: Class
    public string Class { get; set; }
    public string Subclass { get; set; }
    public List<string> ClassFeatures { get; set; } = new List<string>();

    // Step 10: Weapons & Inventory
    public List<CharacterInventory> Inventory { get; set; } = new List<CharacterInventory>();
    public List<CharacterWeapon> Weapons { get; set; } = new List<CharacterWeapon>();

    // Additional properties
    public int ActionPoints { get; set; }
    public List<CharacterAttack> Attacks { get; set; } = new List<CharacterAttack>();
    public List<CharacterResource> Resources { get; set; } = new List<CharacterResource>();
    public int Currency { get; set; }

    public Character()
    {
        Id = Guid.NewGuid();
        Version = CurrentVersion;
        // Skills = SkillConstants.DefaultSkills.Select(s => new Skill(s.Name, s.AttributeUsed, s.Tag)
        // {
        //     Id = s.Id,
        //     Version = s.Version
        // }).ToList();
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