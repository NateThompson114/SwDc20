// using Ardalis.SmartEnum;
//
// namespace SwDc20.Core.Domain.Entities.Weapon.V0._8;
//
// public class Weapon
// {
//     private const string CurrentVersion = "v0.8";
//     
//     public Guid Id { get; set; } = Guid.NewGuid();
//     public string Version { get; set; } = CurrentVersion;
//     public string Name { get; set; }
//     public string Calculation { get; init; }
//     public int Points { get; set; }
//     public List<WeaponProperty> Properties { get; set; } = new();
//     public int PropertyLimit { get; set; }
//     
//     public string GetVersion()
//     {
//         return CurrentVersion;
//     }
//     
//     public static List<MeleeWeapon> CreateMeleeWeapons()
//     {
//         return new()
//         {
//             
//         };
//     }
//     
//     public static List<RangedWeapon> CreateRangedWeapons()
//     {
//         return new();
//     }
//     
//     
//     // public static List<MagicWeapon> CreateMagicWeapons()
//     // {
//     //     return new();
//     // }
// }
//
// public class MeleeWeapon : Weapon
// {
//     public int Reach { get; set; }
//     public int HitBonus { get; set; }
//     public int ThrowRange { get; set; }
//     
//     public bool AddUnwieldy { get; set; }
//     public bool AddTwoHanded { get; set; }
//
//     public MeleeWeapon()
//     {
//         PropertyLimit = 4;
//     }
// }
//
// public class RangedWeapon : Weapon
// {
//     public int Range { get; set; }
//     
//     public bool RemoveUnwieldy { get; set; }
//     public bool RemoveTwoHanded { get; set; }
//
//     public RangedWeapon()
//     {
//         PropertyLimit = 3;
//     }
// }
//
// public class WeaponProperty
// {
//     public string Name { get; set; }
//     public string Description { get; set; }
//     public int Cost { get; set; }
//     public int Damage { get; set; }
//     public string Type { get; set; } // Melee, Ranged, Magic
//     public Variable.V0._8.Variable Variable { get; set; }
//     public string Calculation { get; set; }
//
//     public List<WeaponProperty> GetProperties(WeaponStatics.Property type)
//     {
//         var meleeProperties = new List<WeaponProperty>
//         {
//             new()
//             {
//                 Name = "Capture",
//                 Description = "(Requires: Chained or Whip Style) The Weapon’s damage decreases by 1. When you Attack with this Weapon, you instead make a Martial Check contested by the target’s Physical Save. Creatures that are formless, smaller than Small, or bigger than Large automatically succeed on this Save. Check Success: The target is Grappled by the weapon until it is freed. Forced movement doesn't end the Grapple, but teleportation does. Success (10) The target is also Restrained until it is freed.",
//                 Cost = 0,
//                 Damage = 0,
//                 Type = type.Name,
//                 Variable = WeaponStatics.Variables.BaseDamage,
//                 Calculation = $"{{{WeaponStatics.Variables.BaseDamage}}}"
//             }
//         };
//         
//         var rangedProperties = new List<WeaponProperty>
//         {
//             new()
//             {
//                 Name = "Ammo",
//                 Description = "This Weapon requires ammunition to make Attacks. You can load a Weapon as part of an Attack made with it",
//                 Cost = 1,
//                 Damage = 0,
//                 Type = type.Name,
//                 Variable = WeaponStatics.Variables.BaseDamage,
//                 Calculation = "BaseDamage + 1"
//             }
//         };
//
//         return new();
//     }
// }
//
//
//
//
//
// public static class WeaponStatics
// {
//     public static class Variables
//     {
//         public static Variable.V0._8.Variable BaseDamage = new(nameof(BaseDamage), 1,0, "Base damage for a weapon");
//         public static Variable.V0._8.Variable BasePoints = new(nameof(BasePoints), 2,0,"Base points for a weapon");
//         
//         
//     }
//     
//     public static string GetStringVariable(this Variable variable) => $"{{${variable.Name}}}";
//
//     public class Property: SmartEnum<Property>
//     {
//         public static readonly Property Melee = new(nameof(Melee), 1);
//         public static readonly Property Ranged = new(nameof(Ranged), 2);
//         // public static readonly Property Magic = new(nameof(Magic), 3);
//         public Property(string name, int value) : base(name, value) { }
//     }
// }