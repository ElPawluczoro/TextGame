namespace TextGame.Characters.CharactersSystems;

public class Character
{
    private string characterName;
    private CharacterType characterType;
    private List<ICharactersSystems> characterSystems = new List<ICharactersSystems>();
    
    public Character(string characterName, CharacterType characterType)
    {
        this.characterName = characterName;
        this.characterType = characterType;
    }

    public void AddSystem(ICharactersSystems system)
    {
        characterSystems.Add(system);
    }

    public ACharacterSystem GetSystem(ACharacterSystem system)
    {
        foreach (ACharacterSystem sys in characterSystems)
        {
            if (sys.SystemName == system.SystemName)
            {
                return system;
            }
        }

        return null;
    }
    
    
}