using System.Text.RegularExpressions;
using SwDc20.Core.Application.Constants;
using SwDc20.Core.Domain.Entities.Character.V0._8;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Domain.Entities.Variable.V0._8;

public class Variable: BaseEntity
{
    public const string CurrentVersion = "0.8";
    public string Name { get; set; }
    public int Cost { get; set; }
    public int DamageIncrease { get; set; }
    public int TwoHandedDamageIncrease { get; set; }
    public int BonusToHit { get; set; }
    public int TwoHandedBonusToHit { get; set; }
    public string Description { get; set; }
    public List<Property>? Properties { get; set; }
    public string? Calculation { get; set; }
    public int NestedCount { get; set; } = 0;
    public bool Deletable { get; set; } = true;
    
    public List<VariableModification<Skill>> SkillsModified { get; set; }
    public int MightModification { get; set; }
    public int AgilityModification { get; set; }
    public int CharismaModification { get; set; }
    public int IntelligenceModification { get; set; }
    public int PhysicalDefenseModification { get; set; }
    public string RangeModification { get; set; }
    public int ReachModification { get; set; }
    public int WeaponStyleCountModification { get; set; }
    public int HeavyHitDamageIncrease { get; set; }
    public int BrutalHitDamageIncrease { get; set; }

    public Variable()
    {
        SkillsModified = new List<VariableModification<Skill>>();
        UpdateNestedCount();
    }

    private void UpdateNestedCount()
    {
        if (string.IsNullOrWhiteSpace(Calculation)) return;

        var regex = new Regex(@"\{([^}]+)\}");
        var matches = regex.Matches(Calculation);

        if (matches.Count == 0) return;

        var variables = StandardVariables.ToList();
        int maxNestedCount = 0;

        foreach (Match match in matches)
        {
            string variableName = match.Groups[1].Value;
            var referencedVariable = variables.FirstOrDefault(v => v.Name == variableName);
            if (referencedVariable != null)
            {
                maxNestedCount = Math.Max(maxNestedCount, referencedVariable.NestedCount + 1);
            }
        }

        NestedCount = maxNestedCount;
    }
}

public class VariableModification<TMod>
{
    public VariableModification(TMod itemBeingModified, int value)
    {
        ItemBeingModified = itemBeingModified;
        Value = value;
    }

    public TMod ItemBeingModified { get; set; }
	public int Value { get; set; }
}