namespace SwDc20.Core.Domain.Entities.Character.V0._8;

public class CharacterFeature: BaseEntity
{
    public const string CurrentVersion = "v0.8";
    public string Name { get; set; }
    public string Description { get; set; }
    public string Tag { get; set; }
}