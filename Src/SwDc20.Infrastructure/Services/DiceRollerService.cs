using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace SwDc20.Infrastructure.Services;
public enum RollType
{
    Normal,
    High,
    Low
}

public class DiceRollerService
{
    private readonly IToastService _toastService;

    public DiceRollerService(IToastService toastService)
    {
        _toastService = toastService;
    }

    public void RollDice(int diceSize, int quantity, RollType rollType = RollType.Normal,  string title = null, string description = null)
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

        string rollResult = $"Rolled {quantity}d{diceSize} ({string.Join(", ", rolls)})";
        if (rollType == RollType.High)
            rollResult += $" - Highest: {result}";
        else if (rollType == RollType.Low)
            rollResult += $" - Lowest: {result}";
        else
            rollResult += $" = {result}";

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
            if ((!string.IsNullOrEmpty(title) || !string.IsNullOrEmpty(description)) && !string.IsNullOrEmpty(rollResult))
            {
                builder.AddContent(2, new MarkupString("<hr>"));
            }
            builder.AddContent(3, rollResult);
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