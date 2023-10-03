using TextGame.Characters.Items;
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace TextGame.Characters.CharactersSystems;

public class ItemsInventorySystem : ACharacterSystem
{
    private List<Item> items = new();

    public ItemsInventorySystem()
    {
        systemName = SystemsNames.ItemsInventory;
    }

    public List<Item> GetItemsInInventory()
    {
        return items;
    }

    public Item GetItemFromInventory(int i)
    {
        return items[i];
    }

    public void AddItemToInventory(Item item)
    {
        items.Add(item);
    }

    public new string ToString()
    {
        string _toString = "Inventory:";
        for (int i = 0; i < items.Count; i ++ )
        {
            _toString += "\n" + i + ". " + items[i].ToStringShort();
        }

        return _toString;
    }








}





















