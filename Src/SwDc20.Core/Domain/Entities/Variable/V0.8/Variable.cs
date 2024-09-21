using System.Text.RegularExpressions;
using SwDc20.Core.Application.Constants;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Domain.Entities.Variable.V0._8;

public class Variable: BaseEntity
{
    public const string CurrentVersion = "0.8";
    public string Name { get; set; }
    public int Value { get; set; }
    public int Cost { get; set; }
    public string Description { get; set; }
    public List<Property>? Properties { get; set; }
    public string? Calculation { get; set; }
    public int NestedCount { get; set; } = 0;
    public bool Deletable { get; set; } = true;

    public Variable(string name, int value, int cost = 0, string description = "", List<Property> properties = null, string calculation = null, bool deletable = true)
    {
        Name = name;
        Value = value;
        Cost = cost;
        Description = description;
        Properties = properties;
        Calculation = calculation;
        Deletable = deletable;
        UpdateNestedCount();
    }

    public Variable() { }

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