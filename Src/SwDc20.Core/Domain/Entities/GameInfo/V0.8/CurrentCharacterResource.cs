using SwDc20.Core.Domain.Entities.Character.V0._8;

namespace SwDc20.Core.Domain.Entities.GameInfo.V0._8;

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