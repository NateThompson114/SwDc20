using System.ComponentModel.DataAnnotations;

namespace SwDc20.Core.Domain.Entities.Roll;

public class Dice
{
    [Range(2,1000)]
    public int Size { get; private set; }
    public string DiceType { get; private set; }
    public int? RolledValue { get; private set; }
    public List<int>? ExplodeValues { get; private set; }
    public List<Dice> ExplodedDice { get; set; }

    public Dice(int size, List<int> explodeValues = null)
    {
        if(explodeValues?.Any(v => v > size) ?? false)
        {
            throw new ArgumentOutOfRangeException($"Exploded values ({string.Join(",", explodeValues)}) cannot be greater than dice size({size})");
        }
            
        Size = size;
        DiceType = size == 2 ? "Coin" : $"D{size}";
        ExplodeValues = explodeValues;
        ExplodedDice = new List<Dice>();
    }

    public Dice ChildDice() => new Dice(Size, ExplodeValues);

    public int Roll()
    {
        RolledValue = Random.Shared.Next(1, Size + 1);
        return RolledValue.Value;
    }
}