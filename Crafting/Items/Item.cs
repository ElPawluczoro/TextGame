// ReSharper disable ArrangeThisQualifier
namespace TextGame.Characters.Items;

public abstract class Item
{
    protected string itemName;
    protected int value;
    protected ItemType itemType; public ItemType _ItemType => itemType;

    protected Item(string itemName)
    {
        this.itemName = itemName;
        this.value = 0;
    }

    public void SetValue(int value)
    {
        this.value = value;
    }

    public void SetName(string name)
    {
        this.itemName = name;
    }

    public new string ToString()
    {
        return itemName + "\n" + "Value: " + value + "\n";
    }

    public string ToStringShort()
    {
        return itemName;
    }
    
}