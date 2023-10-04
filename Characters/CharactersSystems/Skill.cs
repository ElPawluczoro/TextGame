namespace TextGame.Characters.CharactersSystems;

public class Skill
{
    private string skillName;
    private int skillLevel;
    
    public string _SkillName => skillName;

    public int _SkillLevel => skillLevel;

    public Skill(string skillName, int skillLevel)
    {
        this.skillName = skillName;
        this.skillLevel = skillLevel;
    }
}