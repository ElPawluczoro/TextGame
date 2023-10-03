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
player.AddSystem(new ItemsInventorySystem());

MaterialsInventorySystem inv = (MaterialsInventorySystem)player.GetSystem(SystemsNames.MaterialsInventory);
CraftingSystem crafting = (CraftingSystem)player.GetSystem(SystemsNames.Crafting);
ItemsInventorySystem itemInv = (ItemsInventorySystem)player.GetSystem(SystemsNames.ItemsInventory);
inv.AddNewMaterial(worldSettings.GetMaterialsInWorld()[1]);
inv.AddMaterialsAmount(worldSettings.GetMaterialsInWorld()[1], 100);
inv.AddNewMaterial(worldSettings.GetMaterialsInWorld()[2]);
inv.AddMaterialsAmount(worldSettings.GetMaterialsInWorld()[2], 100);

int i = 0;
while (i < 5)
{
    i++;
    PeaceOfGear gear1 = (PeaceOfGear)crafting.CraftItem(recipeArmor, inv);
    PeaceOfGear gear2 = (PeaceOfGear)crafting.CraftItem(recipeWeapon, inv);
    itemInv.AddItemToInventory(gear1);
    itemInv.AddItemToInventory(gear2);
}

Console.WriteLine(itemInv.ToString());