using SwDc20.Core.Domain.Entities.Roll;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Domain.ValueObjects;

public record DiceRollResult(
    List<DiceRoll> DiceList,
    DiceRollType RollType,
    List<DiceModifier>? Modifiers,
    int FinalValue, 
    int Double, 
    int Half, 
    string? Header, 
    string? Description);