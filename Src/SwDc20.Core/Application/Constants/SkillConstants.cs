using SwDc20.Core.Domain.Entities.Character.V0._8;

namespace SwDc20.Core.Application.Constants;

public static class SkillConstants
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