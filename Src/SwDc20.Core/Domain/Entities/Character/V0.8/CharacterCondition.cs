namespace SwDc20.Core.Domain.Entities.Character.V0._8;

public class CharacterCondition
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string HelperDescription { get; set; }
	
    public int Duration { get; set; } = -1;
    public int? RemainingDuration { get; set; }
    
    public bool IsTransformationOf { get; set; }
    public string ParentConditionName { get; set; }
    public int TransformationLevel { get; set; }
    public string TransformsIntoName { get; set; }
		
    public int StackCount { get; set; }
    public int StackMax { get; set; } = 1;
    public List<Variable.V0._8.Variable> PerStackVariables { get; set; } = new ();
    public List<HealCondition> PerStackHealConditions { get; set; } = new ();
    public List<HealCondition> MaxStackHealConditions { get; set; } = new ();
	

    public List<HealConditionKeyed> HealConditions { get; set; } = new();
    public List<ConditionalKeyed> ConditionVariables { get; set; } = new();
	
    public List<CharacterCondition> SubConditions { get; set; } = new List<CharacterCondition>();
    public List<CharacterCondition> TransformationConditions { get; set; } = new List<CharacterCondition>();


    public void AddStackCount() 
    {
        if(StackCount == StackMax)
        {
            return;
        }
		
        StackCount++;
		
        if(PerStackVariables.Any())
        {
            ConditionVariables.AddRange(PerStackVariables.Select(aspsv => new ConditionalKeyed(StackCount, aspsv)));
        }

        if (PerStackHealConditions.Any())
        {
            HealConditions.AddRange(PerStackHealConditions.Select(aspsv => new HealConditionKeyed(StackCount, aspsv)));
        }

        if(StackCount == StackMax && MaxStackHealConditions.Any())
        {
            HealConditions.AddRange(MaxStackHealConditions.Select(hc => new HealConditionKeyed(StackCount,hc)));
        }
    }

    public void RemoveStackCount(int? stackCount = null)
    {
        if(StackCount == 0)
        {
            return;
        }
		
        if (PerStackVariables.Any())
        {
            ConditionVariables.RemoveAll(cv => cv.Key == StackCount);
        }

        if (PerStackHealConditions.Any())
        {
            HealConditions.RemoveAll(t => t.Key == StackCount);
        }
		
        if (StackCount == StackMax && MaxStackHealConditions.Any())
        {
            HealConditions.RemoveAll(t => t.Key == StackCount);
        }
        StackCount--;		
    }
	
    public string GetName() => StackCount > 0 && StackMax > 1 ? $"{Name} {StackCount}" : Name;

    public void ResetStackCount()
    { 
        StackCount = 0;
        ConditionVariables.RemoveAll(cv => cv.Key > 0);
        HealConditions.RemoveAll(cv => cv.Key > 0);
    }
	
    public void SetStackMax(int max) => StackMax = max;
}