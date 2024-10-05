using NanoidDotNet;
using SwDc20.Core.Domain.Entities.Character.V0._8;

namespace SwDc20.Core.Domain.Entities.GameInfo.V0._8;

public class Game
{
    public string CampaignName { get; set; }
    public string DungeonMaster { get; set; }
    public string CampaignDescription { get; set; }
    public List<CampaignNote> CampaignNotes { get; set; }
    public List<CurrentCharacter> Characters { get; set; }

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

public class CurrentCharacter
{
    public CurrentCharacter(Character.V0._8.Character character)
    {
        Character = character;
        CurrentStamina = character.MaxStaminaPoints;
        CurrentManaPoints = character.MaxManaPoints;
        CurrentHp = character.MaxHitPoints;
        TemporaryHp = 0;
        CurrentActionPoints = 0;
        CurrentExhaustion = 0;
        CurrentRestPoints = character.RestPoints;
        CurrentGritPoints = character.GritPoints;
        CurrentResources = character.Resources?.Select(cr => new CurrentCharacterResource(0, cr)).ToList() ?? new List<CurrentCharacterResource>();
        CharacterInventory = character.Inventory;
    }

    public Character.V0._8.Character Character { get; set; }
    public bool DefaultCurrentCharacter { get; set; }
    public int CurrentStamina { get; set; }
    public int CurrentManaPoints { get; set; }
    
    public int CurrentHp { get; set; }
    public int TemporaryHp { get; set; }

    public int CurrentActionPoints { get; set; }
    public int CurrentExhaustion { get; set; }
    
    public int CurrentRestPoints { get; set; }
    public int CurrentGritPoints { get; set; }
    
    public List<CurrentCharacterResource> CurrentResources { get; set; }
    public List<CharacterInventory> CharacterInventory { get; set; }
}

public class CurrentCharacterResource
{
    public int CurrentResourceAvailable { get; set; }
    public CharacterResource CharacterResource { get; set; }
    
    public CurrentCharacterResource(int currentResourceAvailable, CharacterResource characterResource)
    {
        CurrentResourceAvailable = currentResourceAvailable;
        CharacterResource = characterResource;
    }
}