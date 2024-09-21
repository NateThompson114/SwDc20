using Ardalis.SmartEnum;

namespace SwDc20.Core.Domain.Entities.Weapon.V0._8;

public class Weapon
{
    private const string CurrentVersion = "v0.8";
    
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Version { get; set; } = CurrentVersion;
    public string Name { get; set; }
    // private string Calculation { get; set; }
    public int Points { get; set; }
    public List<Variable.V0._8.Variable> Properties { get; set; } = new();
    public int PropertyLimit { get; set; }
    
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
        PropertyLimit = 4;
    }
}

public class RangedWeapon : Weapon
{
    public int Range { get; set; }
    
    public bool RemoveUnwieldy { get; set; }
    public bool RemoveTwoHanded { get; set; }

    public RangedWeapon()
    {
        PropertyLimit = 3;
    }
}