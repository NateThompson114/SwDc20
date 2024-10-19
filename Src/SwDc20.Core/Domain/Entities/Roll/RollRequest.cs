namespace SwDc20.Core.Domain.Entities.Roll;

public class RollRequest
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int Modifier { get; set; }
    public bool IsSave { get; set; }
    public string Description { get; set; }
}