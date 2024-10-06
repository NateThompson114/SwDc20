using Blazored.LocalStorage;
using SwDc20.Core.Domain.Entities.GameInfo.V0._8;

namespace SwDc20.Infrastructure.Services;

public class GamesService(ILocalStorageService localStorage)
{
    private const string GameKey = "game";
    
    public async Task<Game?> GetGameAsync()
    {
        return await localStorage.GetItemAsync<Game>(GameKey);
    }
    
    public async Task<List<Game>> GetGamesWithCharactersAsync(Guid characterId)
    {
        var games = await localStorage.GetItemAsync<List<Game>>(GameKey);

        return games.Where(g => g.Characters.Any(c => c.Character.Id == characterId)).ToList();
    }
    
    public async Task SetGameAsync(Game game)
    {
        await localStorage.SetItemAsync(GameKey, game);
    }
    
}