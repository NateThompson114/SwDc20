using SwDc20.Core.Domain.Entities.Roll;

namespace SwDc20.Core.Domain.ValueObjects;

public record DiceRollResult(
    List<DiceRoll> DiceList, 
    int FinalValue, 
    int Double, 
    int Half, 
    string? Header, 
    string? Description);