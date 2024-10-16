using System.ComponentModel.DataAnnotations;
using SwDc20.Core.Application.Constants.Dc20;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Domain.Entities.Weapon.V0._8;

public class Weapon : BaseEntity
{
    public const string CurrentVersion = "v0.8";
    
    [Required]
    public string Name { get; set; }
    
    [Range(0, 100, ErrorMessage = "Points must be 0 or higher"), Required]
    public int Points { get; set; }
    public List<Variable.V0._8.Variable> Properties { get; set; } = new();
    
    [Range(0, int.MaxValue, ErrorMessage = "Property Limit must be 0 or higher"), Required]
    public int PropertyLimit { get; set; }
    
    [Required]
    public VariableProperty PrimaryType { get; set; }
    
    public List<string> DamageTypes { get; set; } = new();

    public string Description { get; set; }
    
    public string GetVersion()
    {
        return CurrentVersion;
    }
    
    public static List<MeleeWeapon> CreateMeleeWeapons()
    {
        return new()
        {
            
        };
    }
    
    public static List<RangedWeapon> CreateRangedWeapons()
    {
        return new();
    }
}

public class MeleeWeapon : Weapon
{
    public int Reach { get; set; }
    public int HitBonus { get; set; }
    public int ThrowRange { get; set; }
    
    public bool AddUnwieldy { get; set; }
    public bool AddTwoHanded { get; set; }

    public MeleeWeapon()
    {
        Points = 2;
        PropertyLimit = 4;
        PrimaryType = VariableProperty.Melee;
        Reach = 1;
        Properties = new()
        {
            Dc20StandardVariables.BaseDamage,
        };
    }
}

public class RangedWeapon : Weapon
{
    public int Range { get; set; }
    
    public bool RemoveUnwieldy { get; set; }
    public bool RemoveTwoHanded { get; set; }

    public RangedWeapon()
    {
        Points = 0;
        PropertyLimit = 3;
        PrimaryType = VariableProperty.Ranged;
        Range = 15;
        Properties = new()
        {
            Dc20StandardVariables.BaseDamage,
            Dc20StandardVariables.Unwieldy,
            Dc20StandardVariables.TwoHanded
        };
    }
}