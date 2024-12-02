using SwDc20.Core.Domain.ValueObjects;

namespace SwDc20.Core.Domain.Entities.Roll;

public class DiceRoll
{
    public Dice Dice { get; }
    public int RolledValue { get; }
    public int FinalValue { get; }
    public List<DiceModifier> Modifiers { get; }
        
    public DiceRoll(Dice dice, List<DiceModifier>? modifiers = null)
    {
        Dice = dice;
        Modifiers = modifiers ?? new List<DiceModifier>();
        RolledValue = dice.Roll();
            
        if (dice.ExplodeValues?.Any() == true)
        {
            HandleExplodingDice(dice);
        }
            
        var childrenValues = Dice.ExplodedDice?.Sum(ed => ed.RolledValue) ?? 0;
        var modifierValues = Modifiers?.Sum(m => m.Modifier) ?? 0;
            
        FinalValue = RolledValue + modifierValues + childrenValues;
    }

    private void HandleExplodingDice(Dice dice)
    {
        var explodedDice = dice.ExplodeValues!.Contains(RolledValue);
        dice.ExplodedDice = new List<Dice>();
            
        while (explodedDice)
        {
            var childDice = Dice.ChildDice();
            var childRoll = childDice.Roll();
            dice.ExplodedDice.Add(childDice);

            explodedDice = dice.ExplodeValues.Contains(childRoll);
        }
    }
}