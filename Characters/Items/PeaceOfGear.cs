// ReSharper disable ParameterHidesMember
// ReSharper disable ArrangeThisQualifier
// ReSharper disable ConvertToAutoProperty
// ReSharper disable FieldCanBeMadeReadOnly.Local
namespace TextGame.Characters.Items;

public class PeaceOfGear : Item
{
    private int vitality;
    private int strength;
    private int dexterity;
    private int intelligence;
    private int armor;
    private GearType gearType;
    private GearRarity gearRarity;
    
    public int _Vitality => vitality;

    public int _Strength => strength;

    public int _Dexterity => dexterity;

    public int _Intelligence => intelligence;

    public int _Armor => armor;

    public GearType _GearType => gearType;
    public GearRarity _GearRarity => gearRarity;

    public ItemType ItemType => itemType;

    public PeaceOfGear(string itemName) : base(itemName)
    {
        gearType = GearType.NONE;
        gearRarity = GearRarity.BASIC;
    }
    
    public PeaceOfGear(string itemName, int vitality, int strength, 
                        int dexterity, int intelligence, int armor, int value, GearType gearType) : base(itemName)
    {
        this.itemType = ItemType.PEACE_OF_GEAR;
        this.gearRarity = GearRarity.BASIC;
        
        this.vitality = vitality;
        this.strength = strength;
        this.dexterity = dexterity;
        this.intelligence = intelligence;
        this.armor = armor;
        this.value = value;
        this.gearType = gearType;
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

    public void SetGearType(GearType gearType)
    {
        this.gearType = gearType;
    }

    public void SetGearRarity(GearRarity gearRarity)
    {
        this.gearRarity = gearRarity;
    }

    public string GearTypeToString()
    {
        switch (gearType)
        {
            case GearType.HELMET:
                return "Helmet";
            case GearType.BOOTS:
                return "Boots";
            case GearType.PANTS:
                return "Pants";
            case GearType.GLOVES:
                return "Gloves";
            case GearType.ONE_HAND_WEAPON:
                return "One hand weapon";
            case GearType.BODY_ARMOR:
                return "Body armor";
            case GearType.TWO_HAND_WEAPON:
                return "Two hand weapon";
            default:
                throw new GearTypeNotProvidedException();
        }
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
    
    public enum GearType
    {
        NONE, HELMET, BODY_ARMOR, GLOVES, PANTS, BOOTS , ONE_HAND_WEAPON, TWO_HAND_WEAPON
    }

    public enum GearRarity
    {
        BASIC, RARE, LEGENDARY, MYTHIC
    }
    
}
































