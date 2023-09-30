using TextGame.Characters;
using TextGame.Characters.CharactersSystems;
using TextGame.Characters.PlayerCharacter;
using TextGame.Crafting;
using TextGame.GeneralMethods;
using TextGame.World;

WorldSettings worldSettings = WorldGenerator.GenerateWorld();

List<Location> locations = worldSettings.GetLocationsInWorld();

Player character1 = new Player("Player");

MaterialsGatherer mg = (MaterialsGatherer)character1.GetSystem(SystemsNames.MaterialsGatherer);
MaterialsInventory inv = (MaterialsInventory)character1.GetSystem(SystemsNames.MaterialsInventory);

inv.AddWorldMaterials(worldSettings);

mg.IncreaseChanceForBonusMaterial(100);
mg.GatherMaterials(locations[1], inv);

StaticMethods.WriteSeparator();

foreach (Material material in worldSettings.GetMaterialsInWorld())
{
    
    Console.WriteLine(material.MaterialName + ": " + inv.GetMaterialAmount(material));
}



