namespace TextGame.Characters.CharactersSystems;

public abstract class Character
{
    protected string characterName;
    protected CharacterType characterType;
    protected List<ACharacterSystem> characterSystems = new List<ACharacterSystem>();
    
    public Character(string characterName)
    {
        this.characterName = characterName; ;
    }

    public void AddRequiredSystems()
    {
        List<ACharacterSystem> systemsToAdd = new();
        
        foreach (ACharacterSystem system in characterSystems)
        {
            foreach (ACharacterSystem requiredSystem in system.GetRequiredSystems())
            {
                systemsToAdd.Add(requiredSystem);
            }
        }

        foreach (ACharacterSystem system in systemsToAdd)
        {
            AddSystem(system);
        }
        
        
    }
    public void AddSystem(ACharacterSystem system)
    {
        foreach (ACharacterSystem s in characterSystems)
        {
            if (s._SystemName == system._SystemName) return;
        }
        characterSystems.Add(system);
        system.SetCharacter(this);
    }

    public ACharacterSystem GetSystem(ACharacterSystem system)
    {
        foreach (ACharacterSystem sys in characterSystems)
        {
            if (sys._SystemName == system._SystemName)
            {
                return sys;
            }
        }

        return null;
    }

    public ACharacterSystem GetSystem(string systemName)
    {
        foreach (ACharacterSystem sys in characterSystems)
        {
            if (sys._SystemName == systemName)
            {
                return sys;
            }
        }

        return null;
    }

    public string GetSystemsToString()
    {
        string _toString = "";
        foreach (ACharacterSystem system in characterSystems)
        {
            _toString += system._SystemName + "\n";
        }

        return _toString;
    }
    
    
}