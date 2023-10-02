using TextGame.Characters.CharactersSystems;
using TextGame.Characters.Items;
using TextGame.Characters.PlayerCharacter;
using TextGame.Crafting;
using TextGame.GeneralMethods;
using TextGame.World;

WorldSettings worldSettings = WorldGenerator.GenerateWorld();

List<Material> materialsR = new();
List<int> materialsRA = new();

materialsR.Add(worldSettings.GetMaterialsInWorld()[1]);
materialsRA.Add(5);
materialsR.Add(worldSettings.GetMaterialsInWorld()[2]);
materialsRA.Add(5);

CraftingRecipe recipeArmor = new("Body Armor", PeaceOfGear.GearType.BODY_ARMOR, materialsR, materialsRA);
CraftingRecipe recipeWeapon = new("Sword", PeaceOfGear.GearType.ONE_HAND_WEAPON, materialsR, materialsRA);

Player player = new Player("Player");
player.AddSystem(new MaterialsInventorySystem());
player.AddSystem(new CraftingSystem());

MaterialsInventorySystem inv = (MaterialsInventorySystem)player.GetSystem(SystemsNames.MaterialsInventory);
CraftingSystem crafting = (CraftingSystem)player.GetSystem(SystemsNames.Crafting);
inv.AddNewMaterial(worldSettings.GetMaterialsInWorld()[1]);
inv.AddMaterialsAmount(worldSettings.GetMaterialsInWorld()[1], 100);
inv.AddNewMaterial(worldSettings.GetMaterialsInWorld()[2]);
inv.AddMaterialsAmount(worldSettings.GetMaterialsInWorld()[2], 100);

PeaceOfGear gear1 = (PeaceOfGear)crafting.CraftItem(recipeArmor, inv);
Console.WriteLine(gear1.ToString());

PeaceOfGear gear2 = (PeaceOfGear)crafting.CraftItem(recipeWeapon, inv);
Console.WriteLine(gear2.ToString());

Console.WriteLine(gear1._GearType);
Console.WriteLine(gear2._GearType);


