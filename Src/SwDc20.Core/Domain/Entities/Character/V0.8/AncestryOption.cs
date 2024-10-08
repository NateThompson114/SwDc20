namespace SwDc20.Core.Domain.Entities.Character.V0._8;

public class AncestryOption: BaseEntity
{
    public const string CurrentVersion = "0.8";
    public List<string> AncestryGroups { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public string Description { get; set; }
    public bool Default { get; set; }
    public int Uniqueness { get; set; }
    
    public List<Variable.V0._8.Variable> Variables { get; set; } = new();
    

    public AncestryOption()
    {
        Id = Guid.NewGuid();
        Version = CurrentVersion;
    }
}