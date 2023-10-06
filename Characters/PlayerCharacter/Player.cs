using TextGame.Characters.CharactersSystems;

namespace TextGame.Characters.PlayerCharacter;

public class Player : Character
{
    public Player(string characterName) : base(characterName)
    {
        characterType = CharacterType.PLAYER_CHARACTER;
        AddSystem(new MaterialsInventorySystem());
        AddSystem(new ItemsInventorySystem());
        AddSystem(new MaterialsGathererSystem());
        AddSystem(new SkillsSystem());
        AddSystem(new CraftingSystem());
        AddRequiredSystems();

        SkillsSystem skillsSystem = (SkillsSystem)GetSystem(SystemsNames.Skills);
        skillsSystem.AddSkill(new Skill(SkillsNames.CraftingSkill, 50));
        skillsSystem.AddSkill(new Skill(SkillsNames.GatheringSkill, 0));

    }
    
    
    
    
}