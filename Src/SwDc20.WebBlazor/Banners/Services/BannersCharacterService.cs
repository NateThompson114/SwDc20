using Blazored.LocalStorage;
using SwDc20.WebBlazor.Banners.Models;

public class BannersCharacterService
{
    private readonly ILocalStorageService _localStorage;
    private const string StorageKey = "banners_characters";

    public BannersCharacterService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<BannersCharacter>> GetCharactersAsync()
    {
        var characters = await _localStorage.GetItemAsync<List<BannersCharacter>>(StorageKey);
        return characters ?? new List<BannersCharacter>();
    }

    public async Task SaveCharacterAsync(BannersCharacter character)
    {
        var characters = await GetCharactersAsync();
        var existingIndex = characters.FindIndex(c => c.Id == character.Id);

        if (existingIndex != -1)
        {
            characters[existingIndex] = character;
        }
        else
        {
            characters.Add(character);
        }

        await _localStorage.SetItemAsync(StorageKey, characters);
    }

    public async Task DeleteCharacterAsync(Guid id)
    {
        var characters = await GetCharactersAsync();
        characters.RemoveAll(c => c.Id == id);
        await _localStorage.SetItemAsync(StorageKey, characters);
    }

    public async Task<BannersCharacter> GetCharacterAsync(Guid id)
    {
        var characters = await GetCharactersAsync();
        return characters.FirstOrDefault(c => c.Id == id);
    }
}