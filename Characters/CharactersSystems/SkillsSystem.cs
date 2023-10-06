namespace TextGame.Characters.CharactersSystems;

public class SkillsSystem : ACharacterSystem
{
    private List<Skill> skills = new();
    public List<Skill> _Skills => skills;

    public SkillsSystem()
    {
        systemName = SystemsNames.Skills;
    }

    public Skill GetSkill(string skillName)
    {
        foreach (Skill skill in skills)
        {
            if (skillName == skill._SkillName)
            {
                return skill;
            }
        }

        return null;
    }

    public Skill GetSkill(Skill skill)
    {
        foreach (Skill s in skills)
        {
            if (s == skill)
            {
                return s;
            }
        }

        return null;
    }

    public void AddSkill(Skill skill)
    {
        skills.Add(skill);
    }


    public override string ToString()
    {
        string _toString = "";
        foreach (Skill skill in skills)
        {
            _toString += skill.ToString() + "\n";
        }

        return _toString;
    }
}












