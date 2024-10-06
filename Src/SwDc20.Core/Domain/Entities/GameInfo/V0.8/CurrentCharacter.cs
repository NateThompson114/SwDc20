using SwDc20.Core.Domain.Entities.Character.V0._8;

namespace SwDc20.Core.Domain.Entities.GameInfo.V0._8;

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