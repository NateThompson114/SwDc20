using Blazored.LocalStorage;
using SwDc20.Core.Domain.Entities.GameInfo.V0._8;

public class CurrentCharacterService
{
    private const string CurrentCharacterKey = "currentCharacter";
    private const string IsCharacterSetupKey = "isCharacterSetup";
    private readonly ILocalStorageService _localStorage;

    public CurrentCharacterService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<CurrentCharacter?> GetCurrentCharacterAsync()
    {
        return await _localStorage.GetItemAsync<CurrentCharacter>(CurrentCharacterKey);
    }

    public async Task SetCurrentCharacterAsync(CurrentCharacter currentCharacter)
    {
        await _localStorage.SetItemAsync(CurrentCharacterKey, currentCharacter);
    }

    public async Task ClearCurrentCharacterAsync()
    {
        await _localStorage.RemoveItemAsync(CurrentCharacterKey);
        await _localStorage.RemoveItemAsync(IsCharacterSetupKey);
    }

    public async Task<bool> IsCharacterSetupAsync()
    {
        return await _localStorage.GetItemAsync<bool>(IsCharacterSetupKey);
    }

    public async Task SetCharacterSetupAsync(bool isSetup)
    {
        await _localStorage.SetItemAsync(IsCharacterSetupKey, isSetup);
    }
}