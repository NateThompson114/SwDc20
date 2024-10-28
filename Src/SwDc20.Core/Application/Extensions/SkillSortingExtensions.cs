using SwDc20.Core.Domain.Entities.Character.V0._8;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Application.Extensions;

public static class SkillSortingExtensions
{
    public static IEnumerable<Skill> OrderByCustomSkillSort(this IEnumerable<Skill> skills)
    {
        return skills
            .OrderBy(s => !string.IsNullOrEmpty(s.Tag)) // No tag first
            .ThenBy(s => CharacterAttribute.FromName(s.AttributeUsed).Value) // Use SmartEnum Value for sort order
            .ThenBy(s => s.Tag ?? "") // Alphabetical by tag
            .ThenBy(s => s.Name); // Then by name within each group
    }
}