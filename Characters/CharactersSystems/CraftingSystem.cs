using TextGame.Characters.Items;
using TextGame.Crafting;

namespace TextGame.Characters.CharactersSystems;

public class CraftingSystem : ACharacterSystem
{
    public CraftingSystem()
    {
        systemName = SystemsNames.Crafting;
    }
    
    public Item CraftItem(CraftingRecipe recipe, MaterialsInventorySystem inventory)
    {
        for (int i = 0; i < recipe.GetNeededMaterials().Count; i++)
        {
            int amount = recipe.GetNeededMaterialsAmount()[i];
            Material material = recipe.GetNeededMaterials()[i];
            if (!inventory.IsMaterialEnough(material, amount))
            {
                Console.WriteLine("Not enough " + material.MaterialName);
                return null;
            }
        }

        for (int i = 0; i < recipe.GetNeededMaterials().Count; i++)
        {
            int amount = recipe.GetNeededMaterialsAmount()[i];
            Material material = recipe.GetNeededMaterials()[i];
            inventory.SpendMaterialsAmount(material, amount);
        }

        Item newItem = new PeaceOfGear("PeaceOfGear");
        
        if (newItem._ItemType == ItemType.PEACE_OF_GEAR)
        {
            PeaceOfGear newPeaceOfGear = (PeaceOfGear)newItem;
            newPeaceOfGear.SetVitality(10);
            newPeaceOfGear.SetArmor(5);
            newPeaceOfGear.SetStrength(5);

            newItem = newPeaceOfGear;
        }

        return newItem;
    }
    
    
    
    
    
    
    
}