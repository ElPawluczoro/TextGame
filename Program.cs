using TextGame.Characters.CharactersSystems;
using TextGame.Characters.Items;
using TextGame.Characters.PlayerCharacter;
using TextGame.Crafting;
using TextGame.GeneralMethods;
using TextGame.World;

WorldSettings worldSettings = WorldGenerator.GenerateWorld();

Player player = new Player("Player");
player.AddSystem(new MaterialsInventorySystem());
player.AddSystem(new CraftingSystem());
player.AddSystem(new ItemsInventorySystem());

MaterialsInventorySystem inv = (MaterialsInventorySystem)player.GetSystem(SystemsNames.MaterialsInventory);
CraftingSystem crafting = (CraftingSystem)player.GetSystem(SystemsNames.Crafting);
ItemsInventorySystem itemInv = (ItemsInventorySystem)player.GetSystem(SystemsNames.ItemsInventory);
inv.AddNewMaterial(worldSettings.GetMaterialsInWorld()[1]);
inv.AddMaterialsAmount(worldSettings.GetMaterialsInWorld()[1], 100);
inv.AddNewMaterial(worldSettings.GetMaterialsInWorld()[2]);
inv.AddMaterialsAmount(worldSettings.GetMaterialsInWorld()[2], 100);

foreach (CraftingRecipe recipe in worldSettings.GetCraftingRecipesInWorld())
{
    Console.WriteLine(recipe.ToString());
}