using TextGame.Crafting;
using TextGame.World;

namespace TextGame.Characters.CharactersSystems;

public class MaterialsGatherer: ACharacterSystem
{
    public MaterialsGatherer()
    {
        systemName = SystemsNames.MaterialsGatherer;
    }
    
    public void GatherMaterials(Location location, MaterialsInventory inv)
    {
        if (!location.GateringAvaiable) return;

        Random random = new Random();
        int iterations = random.Next(5, 10);

        Material material;
        
        for (int i = 0; i < iterations; i++)
        {
            var index = random.Next(0, location.GetAvaiableMaterials().Count);
            material = location.GetAvaiableMaterials()[index];
            inv.AddMaterialsAmount(material, 1);
        }
    }
}