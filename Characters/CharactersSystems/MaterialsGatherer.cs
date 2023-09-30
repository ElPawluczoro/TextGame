using TextGame.Crafting;
using TextGame.World;

namespace TextGame.Characters.CharactersSystems;

public class MaterialsGatherer: ACharacterSystem
{
    private int chanceForBonusMaterial = 0; //max 100
    
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
            if (RollForBonusMaterial())
            {
                inv.AddMaterialsAmount(material, 1);
            }
        }
    }

    public bool RollForBonusMaterial()
    {
        Random random = new Random();
        if (random.Next(1, 100) <= chanceForBonusMaterial) return true;
        return false;
    }

    public void IncreaseChanceForBonusMaterial(int amount)
    {
        chanceForBonusMaterial += amount;
        if (chanceForBonusMaterial > 100) chanceForBonusMaterial = 100;
    }
    
}