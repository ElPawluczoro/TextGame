using TextGame.Characters.CharactersSystems;
using TextGame.Characters.Items;
using TextGame.Characters.PlayerCharacter;
using TextGame.Crafting;
using TextGame.GeneralMethods;
using TextGame.World;

Material material1 = new("Material1");
Material material2 = new("Material2");

List<Material> materialsR = new();
List<int> materialsRA = new();

materialsR.Add(material1);
materialsRA.Add(5);
materialsR.Add(material2);
materialsRA.Add(5);

CraftingRecipe recipe = new(materialsR, materialsRA);

Player player = new Player("Player");
player.AddSystem(new MaterialsInventorySystem());
player.AddSystem(new CraftingSystem());

MaterialsInventorySystem inv = (MaterialsInventorySystem)player.GetSystem(SystemsNames.MaterialsInventory);
CraftingSystem crafting = (CraftingSystem)player.GetSystem(SystemsNames.Crafting);
inv.AddNewMaterial(material1);
inv.AddMaterialsAmount(material1, 10);
inv.AddNewMaterial(material2);
inv.AddMaterialsAmount(material2, 10);

Console.WriteLine("M1: " +inv.GetMaterialAmount(material1));
Console.WriteLine("M2: " +inv.GetMaterialAmount(material2));

PeaceOfGear item = (PeaceOfGear)crafting.CraftItem(recipe, inv);
Console.WriteLine(item.ToString());

Console.WriteLine("M1: " +inv.GetMaterialAmount(material1));
Console.WriteLine("M2: " +inv.GetMaterialAmount(material2));





