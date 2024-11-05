namespace SwDc20.Core.Domain.Entities.Character.V0._8;

// public class CharacterLanguage
// {
//     public string Name { get; set; }
//     public string Proficiency { get; set; } // e.g., "Fluent", "Limited"
//
//     public string? Description { get; set; }
// }

public class Language
{
    public string Name { get; set; }
    public string Proficiency { get; set; } = "Limited"; // e.g., "Fluent", "Limited"
    public string Description { get; set; }
}