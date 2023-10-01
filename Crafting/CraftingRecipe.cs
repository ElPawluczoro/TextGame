using TextGame.Characters.CharactersSystems;
using TextGame.Characters.Items;
// ReSharper disable ConvertToAutoProperty
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace TextGame.Crafting;

public class CraftingRecipe
{
    private string baseName; public string _BaseName => baseName;
    private PeaceOfGear.GearType gearType; public PeaceOfGear.GearType _GearType => gearType;
        
    private List<Material> neededMaterials = new();
    private List<int> neededMaterialsAmount = new();

    public CraftingRecipe()
    {
        gearType = PeaceOfGear.GearType.NONE;
        baseName = "Item";
    }
    
    public CraftingRecipe(string baseName, PeaceOfGear.GearType gearType,
                            List<Material> neededMaterials, List<int> neededMaterialsAmount)
    {
        this.baseName = baseName;
        this.gearType = gearType;
        this.neededMaterials = neededMaterials;
        this.neededMaterialsAmount = neededMaterialsAmount;
    }

    public List<Material> GetNeededMaterials()
    {
        return neededMaterials;
    }
    
    public List<int> GetNeededMaterialsAmount()
    {
        return neededMaterialsAmount;
    }
    




}





















