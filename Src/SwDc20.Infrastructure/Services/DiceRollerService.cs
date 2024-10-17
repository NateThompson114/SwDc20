using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SwDc20.Core.Domain.Entities;
using SwDc20.Core.Domain.Enums;

public class DiceRollerService
{
    private readonly IToastService _toastService;

    public DiceRollerService(IToastService toastService)
    {
        _toastService = toastService;
    }

    public RollResult RollDice(int diceSize, int quantity, int modifier = 0, RollType rollType = RollType.Normal, string title = null, string description = null, bool showRollResults = true)
    {
        var (result, rolls) = PerformRoll(diceSize, quantity, rollType);
        int finalResult = result + modifier;

        if (showRollResults)
        {
            ShowRollResult(diceSize, quantity, rollType, result, rolls, finalResult, modifier, title, description);
        }
        
        return new RollResult(result, rolls, rollType, modifier, finalResult, title, description);
    }

    private (int Result, List<int> Rolls) PerformRoll(int diceSize, int quantity, RollType rollType)
    {
        var random = new Random();
        var rolls = new List<int>();

        for (int i = 0; i < quantity; i++)
        {
            rolls.Add(random.Next(1, diceSize + 1));
        }

        int result = rollType switch
        {
            RollType.High => rolls.Max(),
            RollType.Low => rolls.Min(),
            _ => rolls.Sum()
        };

        return (result, rolls);
    }

    private void ShowRollResult(int diceSize, int quantity, RollType rollType, int result, List<int> rolls, int finalResult, int modifier, string title, string description)
    {
        string rollText = $"Rolled {quantity}d{diceSize} ({string.Join(", ", rolls)})";
        if (rollType == RollType.High)
            rollText += $" - Highest: {result}";
        else if (rollType == RollType.Low)
            rollText += $" - Lowest: {result}";
        else
            rollText += $" = {result}";

        string modifierText = modifier >= 0 ? $"+{modifier}" : modifier.ToString();
        string resultText = $"{rollText} {modifierText} = {finalResult}";

        _toastService.ShowInfo(builder =>
        {
            if (!string.IsNullOrEmpty(title))
            {
                builder.AddContent(0, new MarkupString($"<h4>{title}</h4>"));
            }
            if (!string.IsNullOrEmpty(description))
            {
                builder.AddContent(1, new MarkupString($"<p>{description}</p>"));
            }
            builder.AddContent(2, new MarkupString("<hr>"));
            builder.AddContent(3, resultText);
        }, settings => 
        {
            settings.Timeout = 30;
            settings.ShowProgressBar = true;
            settings.PauseProgressOnHover = true;
            settings.DisableTimeout = false;
            settings.ShowCloseButton = true;
        });
    }
}