using SwDc20.Core.Domain.Entities.Character.V0._8;
using Attribute = SwDc20.Core.Domain.Enums.Attribute;

namespace SwDc20.Core.Application.Constants.Dc20;

public static class Dc20StandardSkills
{
    public static readonly Skill Awareness = new()
    {
        Id = new Guid("b7005fd7-f556-4420-8802-f703ba3c3cad"),
        Version = Skill.CurrentVersion,
        Name = nameof(Awareness),
        AttributeUsed = Attribute.Prime.Name
    };
    public static readonly Skill Athletics = new()
    {
        Id = new Guid("b9e59cc8-91ff-486c-8637-ac9507c81fb7"),
        Version = Skill.CurrentVersion,
        Name = nameof(Athletics),
        AttributeUsed = Attribute.Might.Name,
        UseForMartialCheck = true
    };
    public static readonly Skill Intimidation = new()
    {
        Id = new Guid("bbbcf5dc-272a-4100-b51c-8cb2fee7d773"),
        Version = Skill.CurrentVersion,
        Name = nameof(Intimidation),
        AttributeUsed = Attribute.Might.Name
    };
    public static readonly Skill Acrobatics = new()
    {
        Id = new Guid("293fc737-15d4-479a-8dd9-135c9f251c57"),
        Version = Skill.CurrentVersion,
        Name = nameof(Acrobatics),
        AttributeUsed = Attribute.Agility.Name,
        UseForMartialCheck = true
    };
    public static readonly Skill Trickery = new()
    {
        Id = new Guid("c4dfbd2f-b589-453b-9c27-b1d7a957eda1"),
        Version = Skill.CurrentVersion,
        Name = nameof(Trickery),
        AttributeUsed = Attribute.Agility.Name
    };
    public static readonly Skill Stealth = new()
    {
        Id = new Guid("18319db7-2582-45b1-b7e0-12fd79f953d6"),
        Version = Skill.CurrentVersion,
        Name = nameof(Stealth),
        AttributeUsed = Attribute.Agility.Name
    };
    public static readonly Skill AnimalHandling = new()
    {
        Id = new Guid("69047bc7-01dd-4264-82e6-d3fa457beeb8"),
        Version = Skill.CurrentVersion,
        Name = "Animal Handling",
        AttributeUsed = Attribute.Charisma.Name
    };
    public static readonly Skill Influence = new()
    {
        Id = new Guid("2b639045-a155-4d35-9985-a3fc5acf818e"),
        Version = Skill.CurrentVersion,
        Name = nameof(Influence),
        AttributeUsed = Attribute.Charisma.Name
    };
    public static readonly Skill Insight = new()
    {
        Id = new Guid("8ded413d-3437-4aca-89ec-e1ede9389fc9"),
        Version = Skill.CurrentVersion,
        Name = nameof(Insight),
        AttributeUsed = Attribute.Charisma.Name
    };
    public static readonly Skill Investigation = new()
    {
        Id = new Guid("76865132-818e-4492-aaaa-7947bb20466c"),
        Version = Skill.CurrentVersion,
        Name = nameof(Investigation),
        AttributeUsed = Attribute.Intelligence.Name
    };
    public static readonly Skill Medicine = new()
    {
        Id = new Guid("5d97b05e-f394-4668-bfb8-a0f031f32ef1"),
        Version = Skill.CurrentVersion,
        Name = nameof(Medicine),
        AttributeUsed = Attribute.Intelligence.Name
    };
    public static readonly Skill Survival = new()
    {
        Id = new Guid("89c3d591-9bcc-4a19-9e62-49c4463a9401"),
        Version = Skill.CurrentVersion,
        Name = nameof(Survival),
        AttributeUsed = Attribute.Intelligence.Name
    };
    public static readonly Skill Arcana = new()
    {
        Id = new Guid("a2e75442-a092-41c4-9307-95e88973c4a7"),
        Version = Skill.CurrentVersion,
        Name = nameof(Arcana),
        AttributeUsed = Attribute.Intelligence.Name,
        Tag = "Knowledge"
    };
    public static readonly Skill History = new()
    {
        Id = new Guid("59805d5e-b26d-4ea3-8510-5262cf0493ca"),
        Version = Skill.CurrentVersion,
        Name = nameof(History),
        AttributeUsed = Attribute.Intelligence.Name,
        Tag = "Knowledge"
    };
    public static readonly Skill Nature = new()
    {
        Id = new Guid("c7550e94-9516-4487-bce8-584dabc737e9"),
        Version = Skill.CurrentVersion,
        Name = nameof(Nature),
        AttributeUsed = Attribute.Intelligence.Name,
        Tag = "Knowledge"
    };
    public static readonly Skill Occultism = new()
    {
        Id = new Guid("22a6eca0-e762-4070-8971-70a4615bff77"),
        Version = Skill.CurrentVersion,
        Name = nameof(Occultism),
        AttributeUsed = Attribute.Intelligence.Name,
        Tag = "Knowledge"
    };
    public static readonly Skill Religion = new()
    {
        Id = new Guid("83caf8a2-f106-4c5a-8c72-22bec28a29df"),
        Version = Skill.CurrentVersion,
        Name = nameof(Religion),
        AttributeUsed = Attribute.Intelligence.Name,
        Tag = "Knowledge"
    };
    

    public static List<Skill> DefaultSkills => new()
    {
        Awareness, Athletics, Intimidation, Acrobatics, Trickery, Stealth,
        AnimalHandling, Influence, Insight, Investigation, Medicine, Survival, Arcana, History, Nature, Occultism, Religion
    };

    public static List<string> AttributeOptions => Attribute.GetAttributes().Select(a => a.Name).ToList();
    
}