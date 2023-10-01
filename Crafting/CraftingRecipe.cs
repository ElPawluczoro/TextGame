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
        this.gearType = gearType;
        this.neededMaterials = neededMaterials;
        this.neededMaterialsAmount = neededMaterialsAmount;
        SetBaseName(baseName);
    }

    public List<Material> GetNeededMaterials()
    {
        return neededMaterials;
    }
    
    public List<int> GetNeededMaterialsAmount()
    {
        return neededMaterialsAmount;
    }

    private void SetBaseName(string name)
    {
        baseName = GetMostMaterial().MaterialName + " " + name;
    }

    private Material GetMostMaterial()
    {
        Material material = new Material("Blank");
        int materialAmount = 0;

        for (int i = 0; i < neededMaterials.Count; i++)
        {
            if (neededMaterialsAmount[i] > materialAmount)
            {
                material = neededMaterials[i];
            }
        }
        
        return material;
    }
    




}





















