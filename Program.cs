using TextGame.Characters.CharactersSystems;
using TextGame.Characters.Items;
using TextGame.Characters.PlayerCharacter;
using TextGame.Crafting;
using TextGame.GeneralMethods;
using TextGame.World;

//WorldSettings worldSettings = WorldGenerator.GenerateWorld();

Player player = new Player("Player");

WorldSettings world = WorldGenerator.GenerateWorld();

MaterialsGathererSystem gatherer = (MaterialsGathererSystem)player.GetSystem(SystemsNames.MaterialsGatherer);
MaterialsInventorySystem inv = (MaterialsInventorySystem)player.GetSystem(SystemsNames.MaterialsInventory);
SkillsSystem skills = (SkillsSystem)player.GetSystem(SystemsNames.Skills);

inv.AddWorldMaterials(world);

Console.WriteLine(skills.ToString());

gatherer.GatherMaterials(world.GetLocationsInWorld()[0]);

Console.WriteLine(skills.ToString());

gatherer.GatherMaterials(world.GetLocationsInWorld()[0]);

Console.WriteLine(skills.ToString());
























