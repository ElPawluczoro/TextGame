namespace TextGame.Characters.CharactersSystems;

public abstract class ACharacterSystem
{
    protected string systemName;
    protected Character character;
    public string _SystemName => systemName;

    public void SetCharacter(Character character)
    {
        this.character = character;
    }

    public new abstract string ToString();
}