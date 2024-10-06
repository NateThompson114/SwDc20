using Blazored.LocalStorage;
using SwDc20.Core.Domain.Entities.GameInfo.V0._8;

public class CurrentCharacterService(ILocalStorageService localStorage)
{
    private const string CurrentCharacterKey = "currentCharacter";
    private const string IsCharacterSetupKey = "isCharacterSetup";

    public async Task<CurrentCharacter?> GetCurrentCharacterAsync()
    {
        return await localStorage.GetItemAsync<CurrentCharacter>(CurrentCharacterKey);
    }

    public async Task SetCurrentCharacterAsync(CurrentCharacter currentCharacter)
    {
        await localStorage.SetItemAsync(CurrentCharacterKey, currentCharacter);
    }

    public async Task ClearCurrentCharacterAsync()
    {
        await localStorage.RemoveItemAsync(CurrentCharacterKey);
        await localStorage.RemoveItemAsync(IsCharacterSetupKey);
    }

    public async Task<bool> IsCharacterSetupAsync()
    {
        return await localStorage.GetItemAsync<bool>(IsCharacterSetupKey);
    }

    public async Task SetCharacterSetupAsync(bool isSetup)
    {
        await localStorage.SetItemAsync(IsCharacterSetupKey, isSetup);
    }
}