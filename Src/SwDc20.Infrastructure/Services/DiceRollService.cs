using Blazored.Toast;
using Blazored.Toast.Services;
using SwDc20.Core.Domain.Component;
using SwDc20.Core.Domain.ValueObjects;

namespace SwDc20.Infrastructure.Services;

public class DiceRollService
{
    private readonly IToastService _toastService;

    public DiceRollService(IToastService toastService)
    {
        _toastService = toastService;
    }

    public void ShowRollResult(DiceRollResult result)
    {
        var parameters = new ToastParameters();
        parameters.Add(nameof(DiceRollDisplayComponent.Result), result);

        _toastService.ShowToast<DiceRollDisplayComponent>(parameters, settings => 
        {
            settings.Timeout = 30;
            settings.ShowProgressBar = true;
            settings.PauseProgressOnHover = true;
            settings.DisableTimeout = false;
            settings.ShowCloseButton = true;
        });
    }
}