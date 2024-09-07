using System.Net.Http.Json;
using Blazored.LocalStorage;
using SwDc20.WebBlazor.Models;
using SwDc20.WebBlazor.Models.Character.V0._08;

namespace SwDc20.WebBlazor.Services;

public class CharacterService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;
    private readonly AuthService _authService;
    private const string CharactersKey = "characters";

    public CharacterService(ILocalStorageService localStorage, HttpClient httpClient, AuthService authService)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
        _authService = authService;
    }

    public async Task<List<DocumentWrapper<Character>>> GetCharactersAsync()
    {
        var characters = await _localStorage.GetItemAsync<List<DocumentWrapper<Character>>>(CharactersKey) ?? new List<DocumentWrapper<Character>>();
        return characters;
    }

    public async Task<DocumentWrapper<Character>> GetCharacterAsync(Guid id)
    {
        var characters = await GetCharactersAsync();
        return characters.FirstOrDefault(c => c.ContentId == id);
    }

    public async Task SaveCharacterAsync(DocumentWrapper<Character> characterWrapper)
    {
        var characters = await GetCharactersAsync();
        var existingCharacter = characters.FirstOrDefault(c => c.ContentId == characterWrapper.Document.Id);

        if (existingCharacter != null)
        {
            characters.Remove(existingCharacter);
        }

        characterWrapper.DateUpdated = DateTime.UtcNow;
        characterWrapper.ContentId = characterWrapper.Document.Id;
        characterWrapper.ContentVersion = characterWrapper.Document.Version;
        characters.Add(characterWrapper);

        await _localStorage.SetItemAsync(CharactersKey, characters);

        if (await _authService.IsLoggedInAsync())
        {
            await SyncCharactersAsync();
        }
    }

    public async Task DeleteCharacterAsync(Guid id)
    {
        var characters = await GetCharactersAsync();
        characters.RemoveAll(c => c.ContentId == id);
        await _localStorage.SetItemAsync(CharactersKey, characters);

        if (await _authService.IsLoggedInAsync())
        {
            await SyncCharactersAsync();
        }
    }

    public async Task SyncCharactersAsync()
    {
        //todo: Need to implement the actual syncing logic and db to support it
        return;


        var token = await _authService.GetTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            return;
        }

        var characters = await GetCharactersAsync();
        var response = await _httpClient.PostAsJsonAsync("api/characters/sync", characters);

        if (response.IsSuccessStatusCode)
        {
            var syncedCharacters = await response.Content.ReadFromJsonAsync<List<DocumentWrapper<Character>>>();
            await _localStorage.SetItemAsync(CharactersKey, syncedCharacters);
        }
    }
}