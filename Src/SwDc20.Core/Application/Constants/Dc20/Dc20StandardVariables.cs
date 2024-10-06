using SwDc20.Core.Domain.Entities.Variable.V0._8;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Application.Constants.Dc20;

public static class Dc20StandardVariables
{
    public static Variable Capture = new()
		{
			Id = Guid.Parse("6074cd65-b4cf-4ecd-8353-b2abd7f31746"),
			Version = "0.8",
			Name = nameof(Capture),
			DamageIncrease = -1,
			Description = "When you Attack with this Weapon, you instead make a Martial Check contested by the target’s Physical Save. Success: The target is Grappled by the weapon until it is freed. Forced movement doesn't end the Grapple, but teleportation does. Success (10) The target is also Restrained until it is freed. A creature can spend 1 AP to make a DC 10 Might Check. Success: It can free itself or another creature within its reach. Dealing 1 Slashing damage to the Weapon (PD 10) ends the effect and breaks it, freeing the creature without harming it. A Weapon with this property deals 1 less damage. This Property has no effect on creatures that are formless, smaller than Small or bigger than Large.",
			Properties = new() { Property.Melee }
		};
		public static Variable Guard = new()
		{
			Id = Guid.Parse("7468f90c-908c-45d7-8071-aa87562b0e9f"),
			Version = "0.8",
			Name = nameof(Guard),			
			Cost = 1,
			Description = "You gain +1 PD while wielding the Weapon.",
			Properties = new() { Property.Melee },
			
			PhysicalDefenseModification = 1
		};
		public static Variable MultiFaceted = new()
		{
			Id = Guid.Parse("86b51167-63b6-40c8-97d9-3b6179a1e293"),
			Version = "0.8",
			Name = nameof(MultiFaceted),
			Cost = 1,
			Description = "The Weapon gains a second Weapon Style. When you make an Attack with the Weapon, you must choose which Weapon Style to use. The chosen Weapon Style determines the Attack’s damage type.",
			Properties = new() { Property.Melee },
			
			WeaponStyleCountModification = 1
		};		
		public static Variable Reach = new()
		{
			Id = Guid.Parse("332e1ce2-44b0-45f3-b5a9-303892148e46"),
			Version = "0.8",
			Name = nameof(Reach),
			Cost = 1,
			Description = "This Weapon adds 1 Space to your Melee Range when you Attack with it.",
			Properties = new() { Property.Melee },
			
			ReachModification = 1
		};
		public static Variable Returning = new()
		{
			Id = Guid.Parse("73d97c84-5eba-4f0d-b4aa-fd1770354930"),
			Version = "0.8",
			Name = nameof(Returning),
			Cost = 1,
			Description = "When you Miss a Ranged Attack with the Weapon, it returns to your hand.",
			Properties = new() { Property.Melee }
		};
		public static Variable Toss = new()
		{
			Id = Guid.Parse("4e3f3d2d-e643-4d48-95da-47b156045ad9"),
			Version = "0.8",
			Name = nameof(Toss),
			Cost = 1,
			Description = "You can throw the Weapon to make a Ranged Martial Attack (5/10).",
			Properties = new() { Property.Melee },
			
			RangeModification = 5
		};
		public static Variable Thrown = new()
		{
			Id = Guid.Parse("a318a0e0-fd89-4d68-bf74-4550b49e939e"),
			Version = "0.8",
			Name = nameof(Thrown),
			Cost = 1,
			Description = "You can throw the Weapon to make a Ranged Martial Attack (10/20).",
			Properties = new() { Property.Melee },
			
			RangeModification = 10,
			Requires = new List<Variable>(){Toss}
		};
		public static Variable Versatile = new()
		{
			Id = Guid.Parse("faa02931-e916-481b-b320-48a1a3545f39"),
			Version = "0.8",
			Name = nameof(Versatile),
			Cost = 1,
			Description = "This Weapon can be wielded with 1 or 2 hands. When you wield the Weapon with 2 hands, you gain a +2 bonus to Hit using it.",
			Properties = new() { Property.Melee },
			
			TwoHandedBonusToHit = 2
		};




		public static Variable BaseDamage = new()
		{
			Id = Guid.Parse("363bd34d-02f4-44de-bec1-2314b87c36a9"),
			Version = "0.8",
			Name = nameof(BaseDamage),
			DamageIncrease = 1,
			Description = "Base damage for a weapon",
			Properties = new() { Property.Melee, Property.Ranged },
			
			Deletable = false,
			CountsTowardsMaximumProperties = false
		};
		public static Variable Concealable = new()
		{
			Id = Guid.Parse("227b072d-c004-4605-8831-d26de2d4d3b6"),
			Version = "0.8",
			Name = nameof(Concealable),
			Cost = 1,
			Description = "You have ADV on the first Attack you make against a creature using a concealed Weapon. You can only gain this benefit against each creature once per Combat.",
			Properties = new() { Property.Melee, Property.Ranged }
		};
		public static Variable Heavy = new()
		{
			Id = Guid.Parse("e729d4f2-87a9-47b3-b89a-66082e2b0b9a"),
			Version = "0.8",
			Name = nameof(Heavy),
			Cost = 2,
			DamageIncrease = 1,
			Description = "The Weapon’s damage increases by 1.",
			Properties = new() { Property.Melee, Property.Ranged }
		};
		public static Variable Impact = new()
		{
			Id = Guid.Parse("b7c3b110-8bb8-4af3-b325-91ec8d215308"),
			Version = "0.8",
			Name = nameof(Impact),
			Cost = 1,
			Description = "You deal +1 damage on Heavy Hits.",
			Properties = new() { Property.Melee, Property.Ranged },
			
			HeavyHitDamageIncrease = 1
		};
		public static Variable TwoHanded = new()
		{
			Id = Guid.Parse("78b0cd8b-8112-4708-826c-800b4f293feb"),
			Version = Variable.CurrentVersion,
			Name = nameof(TwoHanded),
			Cost = -1,
			Description = "The Weapon requires 2 hands when you Attack with it.",
			Properties = new() { Property.Melee, Property.Ranged },
			
			CountsTowardsMaximumProperties = false,
			DefaultVariableForProperties = new (){ Property.Melee, Property.Ranged }
		};
		public static Variable Unwieldy = new()
		{
			Id = Guid.Parse("3f2a0219-7ecb-4f8e-8dce-338f2e67457d"),
			Version = Variable.CurrentVersion,
			Name = nameof(Unwieldy),
			Cost = -1,
			Description = "You have DisADV on Attacks made with the Weapon against targets within 1 Space of you.",
			Properties = new() { Property.Melee, Property.Ranged },
			
			CountsTowardsMaximumProperties = false,
			DefaultVariableForProperties = { Property.Melee, Property.Ranged }
		};



		
		public static Variable LongRanged = new()
		{
			Id = Guid.Parse("042a5b80-752a-46e8-8ced-113a9802580d"),
			Version = "0.8",
			Name = nameof(LongRanged),
			Cost = 1,
			Description = "Your Range increases to 30/90.",
			Properties = new() { Property.Ranged },
			
			RangeModification = 30
		};
		public static Variable Ammo = new()
		{
			Id = Guid.Parse("5d41afbf-07e9-4a0e-aa7e-89a5ad5a604c"),
			Version = "0.8",
			Name = nameof(Ammo),
			Description = "This Weapon requires ammunition to make Attacks. You can load a Weapon as part of an Attack made with it.",
			Properties = new() { Property.Ranged }
		};
		public static Variable Reload = new()
		{
			Id = Guid.Parse("b7bc3f16-74bb-4697-98c5-22c0d3ff41c1"),
			Version = "0.8",
			Name = nameof(Reload),
			DamageIncrease = 1,
			Description = "The Weapon’s damage increases by 1, but you must spend 1 AP and use a free hand to reload the Weapon.",
			Properties = new() { Property.Ranged }
		};
		public static Variable Silent = new()
		{
			Id = Guid.Parse("f3d765e5-71d4-4dae-9c39-d891f298d9c5"),
			Version = "0.8",
			Name = nameof(Silent),
			Cost = 1,
			Description = "When you make a Ranged Attack with the Weapon while Hidden, you remain Unheard by creatures you’re Hidden from.",
			Properties = new() { Property.Ranged }
		};

    public static List<Variable> ToList()
    {
        return typeof(Dc20StandardVariables)
            .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
            .Where(f => f.FieldType == typeof(Variable))
            .Select(f => (Variable)f.GetValue(null))
            .OrderBy(v => v.Deletable)
            .ThenBy(v => v.Name)
            .ToList();
    }
}