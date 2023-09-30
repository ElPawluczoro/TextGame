using TextGame.Crafting;
using TextGame.World;

namespace TextGame.Characters.CharactersSystems;

public class MaterialsInventorySystem : ACharacterSystem
{
    private List<Material> materials = new List<Material>();
    private IDictionary<string, int> materialsAmount = new Dictionary<string, int>();

    public MaterialsInventorySystem()
    {
        systemName = SystemsNames.MaterialsInventory;
    }

    public void AddNewMaterial(Material material)
    {
        materials.Add(material);
        materialsAmount.Add(material.MaterialName, 0);
    }

    public void AddWorldMaterials(WorldSettings worldSettings)
    {
        foreach (Material material in worldSettings.GetMaterialsInWorld())
        {
            AddNewMaterial(material);
        }
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
        Console.WriteLine(amount + " " + material.MaterialName + " added");
    }

    public void SpendMaterialsAmount(Material material, int amount)
    {
        string materialName = "";
        foreach (var m in materialsAmount)
        {
            if (material.MaterialName != m.Key) continue;
            materialName = material.MaterialName;
            break;
        }

        materialsAmount[materialName] -= amount;
        Console.WriteLine(amount + " " + material.MaterialName + " spent");
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

    public bool IsMaterialEnough(Material material, int amount)
    {
        if (GetMaterialAmount(material) < amount) return false;
        return true;
    }
    
    
}