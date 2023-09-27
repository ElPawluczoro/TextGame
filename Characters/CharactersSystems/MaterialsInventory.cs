using TextGame.Crafting;

namespace TextGame.Characters.CharactersSystems;

public class MaterialsInventory : ACharacterSystem
{
    private List<Material> materials = new List<Material>();
    private IDictionary<string, int> materialsAmount = new Dictionary<string, int>();

    public MaterialsInventory()
    {
        systemName = "MaterialsInventorySystem";
    }

    public void AddNewMaterial(Material material)
    {
        materials.Add(material);
        materialsAmount.Add(material.MaterialName, 0);
    }
    
    public void AddMaterialsAmount(Material material, int amount)
    {
        string materialName = "";
        foreach (var m in materialsAmount)
        {
            if (material.MaterialName != m.Key) continue;
            materialName = material.MaterialName;
            break;
        }

        materialsAmount[materialName] += amount;
    }

    public string GetMaterialName(int i)
    {
        if (i > materials.Count - 1) return null;
        return materials[i].MaterialName;
    }

    public int GetMaterialAmount(Material material)
    {
        return materialsAmount[material.MaterialName];
    }
    
    
}