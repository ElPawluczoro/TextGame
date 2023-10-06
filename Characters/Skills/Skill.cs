namespace TextGame.Characters.CharactersSystems;

public class Skill
{
    private readonly string skillName;
    private int skillLevel;
    private readonly int maxSkillLevel;

    public string _SkillName => skillName;
    public int _SkillLevel => skillLevel;
    public int _MaxSkillLevel => maxSkillLevel;

    public Skill(string skillName, int skillLevel, int maxSkillLevel)
    {
        this.skillName = skillName;
        this.skillLevel = skillLevel;
        this.maxSkillLevel = maxSkillLevel;
    }

    public void IncreaseLevel(int amount)
    {
        if (skillLevel == maxSkillLevel)
        {
            return;
        }
        
        skillLevel += amount;
        
        if (skillLevel > maxSkillLevel)
        {
            skillLevel = maxSkillLevel;
        }
    }

    public new string ToString()
    {
        return _SkillName + " " + skillLevel + "lv";
    }
    
}