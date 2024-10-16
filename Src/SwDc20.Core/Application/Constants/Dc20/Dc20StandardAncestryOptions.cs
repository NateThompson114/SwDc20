using SwDc20.Core.Domain.Entities.Character.V0._8;
using SwDc20.Core.Domain.Entities.Variable.V0._8;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Application.Constants.Dc20;

public static class Dc20StandardAncestryOptions
{
    public static readonly AncestryOption AttributeIncrease = new()
    {
        Id = new Guid("5847e4a3-89df-459d-9614-50075aba2f5b"),
        Version = AncestryOption.CurrentVersion,
        Name = "Attribute Increase",
        Description = "Choose an Attribute. The chosen Attribute increases by 1 (up to the Attribute Limit).",
        Cost = 2,
        Default = true,
        AncestryGroups = [Dc20StandardAncestryGroups.Human],
        
        Variables = new List<Variable>
        {
            Dc20StandardAncestryVariables.AttributeIncrease
        }
    };
    
    public static readonly AncestryOption Resilience = new()
    {
        Id = new Guid("3acf5c33-2ae3-4c92-9b09-f18925df0b10"),
        Version = AncestryOption.CurrentVersion,
        Name = "Resilience",
        Description = "Choose an Attribute. The chosen Attribute gains Save Mastery.",
        Cost = 2,
        Default = true,
        AncestryGroups = [Dc20StandardAncestryGroups.Human],
        Uniqueness = 2,
        
        Variables = new List<Variable>
        {
            Dc20StandardAncestryVariables.AddSaveMasteryToAttribute
        }
    };

    public static readonly AncestryOption HumanResolve = new AncestryOption
    {
        Id = new Guid(""),
        Version = AncestryOption.CurrentVersion,
        Name = "Human Resolve",
        Description = "Your Deaths Door Threshold value is expanded by 1.",
        Cost = 1,
        Default = true,
        AncestryGroups = [Dc20StandardAncestryGroups.Human],
        
        Variables = new List<Variable>
        {
            Dc20StandardAncestryVariables.DeathDoorThresholdIncrease
        }
    };
}

public static class Dc20StandardAncestryVariables
{
    public static Variable AttributeIncrease = new()
    {
        Id = new Guid("568f18d8-aa59-4f56-a830-eef97b2db9fa"),
        Version = Variable.CurrentVersion,
        Name = "Attribute",
        Description = "Choose an Attribute. The chosen Attribute increases by 1 (up to the Attribute Limit).",
        Cost = 2,
        Properties = [VariableProperty.Ancestry],
        
        ChooseAttributeToModify = new AttributeToModify
        {
            Amount = 1
        }
    };
    public static Variable AddSaveMasteryToAttribute = new()
    {
        Id = new Guid("d133870a-2433-4fee-87cc-1dadbddda656"),
        Version = Variable.CurrentVersion,
        Name = "Physical Defense",
        Description = "Choose an Attribute. The chosen Attribute gains Save Mastery.",
        Cost = 2,
        Properties = [VariableProperty.Ancestry],
        
        ChooseAttributeToModify = new AttributeToModify
        {
            GainSaveMastery = true
        }
    };
    public static Variable DeathDoorThresholdIncrease = new()
    {
        Id = new Guid(""),
        Version = Variable.CurrentVersion,
        Name = "Deaths Door Threshold Increase",
        Description = "Your Deaths Door Threshold value is expanded by 1.",
        Cost = 1,
        Properties = [VariableProperty.Ancestry],
        
        DeathModification = new Death()
        {
            DeathDoorThresholdChange = 1
        }
    };
}

public static class Dc20StandardAncestryGroups
{
    public const string Human = nameof(Human);
    public const string Elf = nameof(Elf);
    public const string Dwarf = nameof(Dwarf);
    public const string Halfling = nameof(Halfling);
    public const string Gnome = nameof(Gnome);
    public const string Orc = nameof(Orc);
    public const string Dragonborn = nameof(Dragonborn);
    public const string Giantborn = nameof(Giantborn);
    public const string Angelborn = nameof(Angelborn);
    public const string Fiendborn = nameof(Fiendborn);
    public const string Beastborn = nameof(Beastborn);
}