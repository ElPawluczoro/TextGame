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

CraftingRecipe recipe = new("Body Armor", PeaceOfGear.GearType.BODY_ARMOR, materialsR, materialsRA);

Player player = new Player("Player");
player.AddSystem(new MaterialsInventorySystem());
player.AddSystem(new CraftingSystem());

MaterialsInventorySystem inv = (MaterialsInventorySystem)player.GetSystem(SystemsNames.MaterialsInventory);
CraftingSystem crafting = (CraftingSystem)player.GetSystem(SystemsNames.Crafting);
inv.AddNewMaterial(worldSettings.GetMaterialsInWorld()[1]);
inv.AddMaterialsAmount(worldSettings.GetMaterialsInWorld()[1], 100);
inv.AddNewMaterial(worldSettings.GetMaterialsInWorld()[2]);
inv.AddMaterialsAmount(worldSettings.GetMaterialsInWorld()[2], 100);

while (inv.GetMaterialAmount(worldSettings.GetMaterialsInWorld()[1]) >= 5)
{
    PeaceOfGear item = (PeaceOfGear)crafting.CraftItem(recipe, inv);
    Console.WriteLine(item.ToString());
}




