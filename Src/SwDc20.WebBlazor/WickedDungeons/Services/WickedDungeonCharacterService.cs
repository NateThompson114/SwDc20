using Blazored.LocalStorage;
using SwDc20.WebBlazor.WickedDungeons.Models;

public class WickedDungeonCharacterService
{
    private readonly ILocalStorageService _localStorage;
    private const string StorageKey = "wicked_dungeons_characters";

    public WickedDungeonCharacterService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<WickedDungeonCharacter>> GetCharactersAsync()
    {
        var characters = await _localStorage.GetItemAsync<List<WickedDungeonCharacter>>(StorageKey);
        return characters ?? new List<WickedDungeonCharacter>();
    }

    public async Task SaveCharacterAsync(WickedDungeonCharacter character)
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

    public async Task<WickedDungeonCharacter> GetCharacterAsync(Guid id)
    {
        var characters = await GetCharactersAsync();
        return characters.FirstOrDefault(c => c.Id == id);
    }
}