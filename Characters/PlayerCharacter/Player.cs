using TextGame.Characters.CharactersSystems;

namespace TextGame.Characters.PlayerCharacter;

public class Player : Character
{
    public Player(string characterName) : base(characterName)
    {
        characterType = CharacterType.PLAYER_CHARACTER;
        //AddSystem(new MaterialsInventorySystem());
        //AddSystem(new ItemsInventorySystem());
        AddSystem(new MaterialsGathererSystem());
        AddSystem(new SkillsSystem());
        AddSystem(new CraftingSystem());
        AddRequiredSystems();
    }
    
    
    
    
}