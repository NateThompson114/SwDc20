using SwDc20.Core.Domain.Enums;
using SwDc20.Core.Domain.ValueObjects;

namespace SwDc20.Core.Domain.Entities.Roll;

public static class DiceRollerExtensions
{
    public static DiceRollResult Roll(
        this Dice dice, 
        int quantity = 1, 
        DiceRollType rollType = DiceRollType.Normal, 
        string? header = null, 
        string? description = null, 
        List<DiceModifier>? modifiers = null)
    {
        if(quantity < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Dice roll quantity needs to be 1 or greater");
        }
            
        if(rollType == DiceRollType.Normal && quantity > 1)
        {
            throw new ArgumentException("Normal rolls should only have one dice, otherwise use dice pool", nameof(quantity));
        }
            
        var rollResults = new List<DiceRoll>();
            
        for (int i = 0; i < quantity; i++)
        {
            var rollDice = dice.ChildDice();
            rollResults.Add(new DiceRoll(rollDice, modifiers));
        }
            
        var result = rollType switch
        {
            DiceRollType.KeepLowest => rollResults.Min(r => r.FinalValue),
            DiceRollType.Normal => rollResults.Sum(r => r.FinalValue),
            DiceRollType.KeepHighest => rollResults.Max(r => r.FinalValue),
            DiceRollType.Pool => rollResults.Sum(r => r.FinalValue),
            _ => throw new NotSupportedException($"Roll type {rollType} is not supported")
        };
            
        var doubleValue = (int)Math.Round(result * 2.0, MidpointRounding.AwayFromZero);
        var halfValue = (int)Math.Round(result / 2.0, MidpointRounding.ToZero);
            
        return new DiceRollResult(rollResults, rollType, modifiers, result, doubleValue, halfValue, header, description);
    }
}