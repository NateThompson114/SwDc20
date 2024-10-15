using NanoidDotNet;

namespace SwDc20.Core.Domain.Entities.GameInfo.V0._8;

public class Game
{
    public string CampaignName { get; set; }
    public string DungeonMaster { get; set; }
    public string CampaignDescription { get; set; }
    public List<CampaignNote> CampaignNotes { get; set; }
    public List<Character.V0._8.Character> Characters { get; set; }

    public string GameKey { get; init; }
    public List<string> GameJoinKey { get; init; }
    public string GameVersion { get; init; }
    

    public Game()
    {
        // Key that identifies the game
        GameKey = Nanoid.Generate(_full, 40);
        
        // Key that allows players to join the game, can be deleted and recreated
        GameJoinKey = new List<string>(){ Nanoid.Generate(_full, 100) };
    }
    
    private string _numbers = "0123456789";
    private string _alphabet = "abcdefghijklmnopqrstuvwxyz";

    private string _full => $"{_numbers}{_alphabet}{_alphabet.ToUpper()}";
    
}

public class CampaignNote
{
    public DateTime Created { get; init; }
    public string Note { get; set; }
}