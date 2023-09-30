using TextGame.Characters.CharactersSystems;

namespace TextGame.Characters.PlayerCharacter;

public class Player : Character
{
    public Player(string characterName) : base(characterName)
    {
        characterType = CharacterType.PLAYER_CHARACTER;
        AddSystem(new MaterialsInventory());
        AddSystem(new MaterialsGatherer());
    }
    
    
    
    
}