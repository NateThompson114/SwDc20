using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Domain.Entities.Roll;

public class RollResult
{
    public int Result { get; set; }
    public List<int> IndividualRolls { get; set; }
    public RollType ResultRollType { get; set; }
    public int Modifier { get; set; }
    public int FinalResult { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public int Quantity { get; set; }
    public int DiceSize { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    

    public RollResult(int result, List<int> individualRolls, RollType rollType, int modifier, int finalResult, string? title = null, string? description = null)
    {
        Result = result;
        IndividualRolls = individualRolls;
        ResultRollType = rollType;
        Modifier = modifier;
        FinalResult = finalResult;
        Title = title;
        Description = description;
    }
}