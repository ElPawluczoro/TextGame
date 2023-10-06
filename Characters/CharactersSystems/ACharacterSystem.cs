namespace TextGame.Characters.CharactersSystems;

public abstract class ACharacterSystem
{
    protected string systemName;
    protected Character character;
    public string _SystemName => systemName;

    protected List<ACharacterSystem> requiredSystems = new();

    public List<ACharacterSystem> GetRequiredSystems()
    {
        return requiredSystems;
    }

    public void SetCharacter(Character character)
    {
        this.character = character;
    }

    public new abstract string ToString();
}