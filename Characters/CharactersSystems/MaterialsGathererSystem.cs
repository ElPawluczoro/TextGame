using TextGame.Crafting;
using TextGame.World;

namespace TextGame.Characters.CharactersSystems;

public class MaterialsGathererSystem: ACharacterSystem
{
    private int chanceForBonusMaterial = 0; //max 100
    
    public MaterialsGathererSystem()
    {
        systemName = SystemsNames.MaterialsGatherer;
        requiredSystems.Add(new MaterialsInventorySystem());
    }

    private void UpdateChanceForBonusMaterial()
    {
        SkillsSystem characterSkills = (SkillsSystem)character.GetSystem(SystemsNames.Skills);
        chanceForBonusMaterial = characterSkills.GetSkill(SkillsNames.GatheringSkill)._SkillLevel / 10;
    }
    
    public void GatherMaterials(Location location)
    {
        if (!location.GateringAvaiable) return;
        MaterialsInventorySystem inv = (MaterialsInventorySystem)character.GetSystem(SystemsNames.MaterialsInventory);

        UpdateChanceForBonusMaterial();
        
        Random random = new Random();
        int iterations = random.Next(5, 10);

        Material material;
        
        for (int i = 0; i < iterations; i++)
        {
            var index = random.Next(0, location.GetAvaiableMaterials().Count);
            material = location.GetAvaiableMaterials()[index];

            RollForLevelIncrease();
            
            if (RollForBonusMaterial())
            {
                inv.AddMaterialsAmount(material, 2);
            }
            else
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

    public void RollForLevelIncrease()
    {
        Random random = new();
        SkillsSystem skills = (SkillsSystem)character.GetSystem(SystemsNames.Skills);
        int successRange = 1100 - skills.GetSkill(SkillsNames.CraftingSkill)._SkillLevel;

        if (successRange >= random.Next(1, 1100))
        {
            skills.GetSkill(SkillsNames.GatheringSkill).IncreaseLevel(1);
        }
        
    }

    public override string ToString()
    {
        return "";
    }
}