using TextGame.Characters.CharactersSystems;
using TextGame.Characters.Items;

namespace TextGame.Crafting;

public class CraftingRecipe
{
    private List<Material> neededMaterials = new();
    private List<int> neededMaterialsAmount = new();

    public CraftingRecipe()
    {
        
    }
    
    public CraftingRecipe(List<Material> neededMaterials, List<int> neededMaterialsAmount)
    {
        this.neededMaterials = neededMaterials;
        this.neededMaterialsAmount = neededMaterialsAmount;
    }

    public List<Material> GetNeededMaterials()
    {
        return neededMaterials;
    }
    
    public List<int>  GetNeededMaterialsAmount()
    {
        return neededMaterialsAmount;
    }
    




}





















