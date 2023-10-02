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
    private int minArmorDamageRoll = 1;
    private int maxArmorDamageRoll = 5;
    private int minStatRoll = 1;
    private int maxStatRoll = 10;
    
    public int MinArmorDamageRoll => minArmorDamageRoll;

    public int MaxArmorDamageRoll => maxArmorDamageRoll;

    public int MinStatRoll => minStatRoll;

    public int MaxStatRoll => maxStatRoll;

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
        SetMinAndMaxRolls();
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
        baseName = GetMostMaterial()._MaterialName + " " + name;
    }

    private void SetMinAndMaxRolls()
    {
        Material mostMaterial = GetMostMaterial();
        minArmorDamageRoll = (int)Math.Round(mostMaterial._MaterialHardness / 10M);
        if (minArmorDamageRoll < 1) minArmorDamageRoll = 1;
        maxArmorDamageRoll = (int)Math.Round(mostMaterial._MaterialHardness / 5M);
        if (maxArmorDamageRoll < 4) maxArmorDamageRoll = 4;

        if (mostMaterial._MaterialMagic < 5) minStatRoll = 1;
        else if (mostMaterial._MaterialMagic < 8) minStatRoll = 2;
        else minStatRoll = 3;
        
        maxStatRoll = mostMaterial._MaterialMagic;
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





















