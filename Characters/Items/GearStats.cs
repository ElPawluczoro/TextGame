namespace TextGame.Characters.Items;

public class GearStats
{
    
    public static readonly Stats[] statsPossible =
    {
        Stats.VITALITY,
        Stats.STRENGTH,
        Stats.DEXTERITY,
        Stats.INTELLIGENCE,
        Stats.ARMOR
    };

    public static void RemoveAlreadyUsedStatsFromList(PeaceOfGear peaceOfGear, List<Stats> statsList)
    {
        if (peaceOfGear._Vitality > 0) statsList.Remove(Stats.VITALITY);
        if (peaceOfGear._Strength > 0) statsList.Remove(Stats.STRENGTH);
        if (peaceOfGear._Dexterity > 0) statsList.Remove(Stats.DEXTERITY);
        if (peaceOfGear._Intelligence > 0) statsList.Remove(Stats.INTELLIGENCE);
        if (peaceOfGear._Armor > 0) statsList.Remove(Stats.ARMOR);
    }
    
    public enum Stats
    {
        VITALITY, STRENGTH, DEXTERITY, INTELLIGENCE, ARMOR
    }
}