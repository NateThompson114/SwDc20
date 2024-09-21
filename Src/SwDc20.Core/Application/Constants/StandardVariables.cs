using SwDc20.Core.Domain.Entities.Variable.V0._8;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Application.Constants;

public static class StandardVariables
{
    public static Variable BaseDamage = new(nameof(BaseDamage), 1, 0, "Base damage for a weapon", new() { Property.Melee, Property.Ranged })
    {
        Id = Guid.Parse("363bd34d-02f4-44de-bec1-2314b87c36a9"),
        Version = "0.8",
        Deletable = false
    };
    public static Variable Capture = new(nameof(Capture), 0, -1, "", new() { Property.Melee })
    {
        Id = Guid.Parse("6074cd65-b4cf-4ecd-8353-b2abd7f31746"),
        Version = "0.8"
    };
    public static Variable Concealable = new(nameof(Concealable), 1, 0, "", new() { Property.Melee, Property.Ranged })
    {
        Id = Guid.Parse("227b072d-c004-4605-8831-d26de2d4d3b6"),
        Version = "0.8"
    };
    public static Variable Guard = new(nameof(Guard), 1, 0, "", new() { Property.Melee })
    {
        Id = Guid.Parse("7468f90c-908c-45d7-8071-aa87562b0e9f"),
        Version = "0.8"
    };
    public static Variable Heavy = new(nameof(Heavy), 2, 1, "", new() { Property.Melee, Property.Ranged })
    {
        Id = Guid.Parse("e729d4f2-87a9-47b3-b89a-66082e2b0b9a"),
        Version = "0.8"
    };
    public static Variable Impact = new(nameof(Impact), 1, 0, "", new() { Property.Melee, Property.Ranged })
    {
        Id = Guid.Parse("b7c3b110-8bb8-4af3-b325-91ec8d215308"),
        Version = "0.8"
    };
    public static Variable MultiFaceted = new(nameof(MultiFaceted), 1, 0, "", new() { Property.Melee })
    {
        Id = Guid.Parse("86b51167-63b6-40c8-97d9-3b6179a1e293"),
        Version = "0.8"
    };
    public static Variable None = new(nameof(None), 0, 0, "", new() { Property.Melee, Property.Ranged })
    {
        Id = Guid.Parse("52f6fbad-020f-4810-9890-bd61e8e7b5f8"),
        Version = "0.8",
        Deletable = false
    };
    public static Variable Reach = new(nameof(Reach), 1, 0, "", new() { Property.Melee })
    {
        Id = Guid.Parse("332e1ce2-44b0-45f3-b5a9-303892148e46"),
        Version = "0.8"
    };
    public static Variable Returning = new(nameof(Returning), 1, 0, "", new() { Property.Melee })
    {
        Id = Guid.Parse("73d97c84-5eba-4f0d-b4aa-fd1770354930"),
        Version = "0.8"
    };
    public static Variable Thrown = new(nameof(Thrown), 1, 0, "", new() { Property.Melee })
    {
        Id = Guid.Parse("a318a0e0-fd89-4d68-bf74-4550b49e939e"),
        Version = "0.8"
    };
    public static Variable Toss = new(nameof(Toss), 1, 0, "", new() { Property.Melee })
    {
        Id = Guid.Parse("4e3f3d2d-e643-4d48-95da-47b156045ad9"),
        Version = "0.8"
    };
    public static Variable Versatile = new(nameof(Versatile), 1, 0, "", new() { Property.Melee })
    {
        Id = Guid.Parse("faa02931-e916-481b-b320-48a1a3545f39"),
        Version = "0.8"
    };



    public static Variable LongRanged = new(nameof(LongRanged), 1, 0, "", new() { Property.Ranged })
    {
        Id = Guid.Parse("042a5b80-752a-46e8-8ced-113a9802580d"),
        Version = "0.8"
    };
    public static Variable Reload = new(nameof(Reload), 0, 1, "", new() { Property.Ranged })
    {
        Id = Guid.Parse("b7bc3f16-74bb-4697-98c5-22c0d3ff41c1"),
        Version = "0.8"
    };
    public static Variable Silent = new(nameof(Silent), 1, 0, "", new() { Property.Ranged })
    {
        Id = Guid.Parse("f3d765e5-71d4-4dae-9c39-d891f298d9c5"),
        Version = "0.8"
    };

    public static List<Variable> ToList()
    {
        return typeof(StandardVariables)
            .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
            .Where(f => f.FieldType == typeof(Variable))
            .Select(f => (Variable)f.GetValue(null))
            .ToList();
    }
}