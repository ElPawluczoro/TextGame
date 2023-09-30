// ReSharper disable ParameterHidesMember
namespace TextGame.Characters.Items;

public class PeaceOfGear : Item
{
    private int vitality;
    private int strength;
    private int dexterity;
    private int intelligence;
    private int armor;

    public PeaceOfGear(string itemName) : base(itemName)
    {
        
    }
    
    public PeaceOfGear(string itemName, int vitality, int strength, 
                        int dexterity, int intelligence, int armor, int value) : base(itemName)
    {
        this.itemType = ItemType.PEACE_OF_GEAR;
        
        this.vitality = vitality;
        this.strength = strength;
        this.dexterity = dexterity;
        this.intelligence = intelligence;
        this.armor = armor;
        this.value = value;
    }

    public void SetVitality(int vitality)
    {
        this.vitality = vitality;
    }    
    
    public void SetStrength(int strength)
    {
        this.strength = strength;
    }
    
    public void SetDexterity(int dexterity)
    {
        this.dexterity = dexterity;
    }
    
    public void SetIntelligence(int intelligence)
    {
        this.intelligence = intelligence;
    }

    public void SetArmor(int armor)
    {
        this.armor = armor;
    }

    public new string ToString()
    {
        string _toString  = base.ToString();

        if (vitality > 0) _toString += "Vitality: " + vitality + "\n";
        if (strength > 0) _toString += "strength: " + strength + "\n";
        if (dexterity > 0) _toString += "dexterity: " + dexterity + "\n";
        if (intelligence > 0) _toString += "intelligence: " + intelligence + "\n";
        if (armor > 0) _toString += "armor: " + armor + "\n";
        
        return _toString;
    }
    
}
































