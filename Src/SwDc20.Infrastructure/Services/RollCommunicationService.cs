using SwDc20.Core.Domain.Enums;

namespace SwDc20.Infrastructure.Services;

public class RollCommunicationService
{
    public event Action<int, int, int, RollType, string, string> OnRollRequested;

    public void RequestRoll(int diceSize, int quantity, int modifier, RollType rollType, string title, string description)
    {
        OnRollRequested?.Invoke(diceSize, quantity, modifier, rollType, title, description);
    }
}