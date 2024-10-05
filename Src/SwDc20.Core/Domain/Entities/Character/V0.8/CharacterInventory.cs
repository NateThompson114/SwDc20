namespace SwDc20.Core.Domain.Entities.Character.V0._8;

public class CharacterInventory: BaseEntity
{
    public const string CurrentVersion = "v0.8";

    public string Name { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public double Value { get; set; }
    public string Type { get; set; }
    public bool IsContainer { get; set; }
    public double WeightCapacity { get; set; }
    
    public List<CharacterInventory> Inventory { get; set; } = new List<CharacterInventory>();
    
    public CharacterInventory()
    {
        if (!IsContainer)
        {
            return;
        }
        
        Type = "Container";
        Quantity = 1;
    }
    
    public double RemainingCapacity => WeightCapacity - Inventory.Sum(i => i.Weight);
    public double StackWeight => Quantity * Weight;
    
    public Task<string> AddInventory(CharacterInventory inventory)
    {
        var weight = StackWeight;
        if (weight > RemainingCapacity)
        {
            return Task.FromResult("Not enough space in container");
        }
        Inventory.Add(inventory);
        return Task.FromResult($"Added {Math.Min(inventory.Quantity, 1)} {inventory.Name}{(inventory.Quantity > 1 ? "s" : "")} to inventory");
    }
}