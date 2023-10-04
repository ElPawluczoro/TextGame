using TextGame.Characters.CharactersSystems;
using TextGame.Characters.Items;
using TextGame.Characters.PlayerCharacter;
using TextGame.Crafting;
using TextGame.GeneralMethods;
using TextGame.World;

//WorldSettings worldSettings = WorldGenerator.GenerateWorld();

Player player = new Player("Player");

MaterialsInventorySystem inv = (MaterialsInventorySystem)player.GetSystem(SystemsNames.MaterialsInventory);
CraftingSystem crafting = (CraftingSystem)player.GetSystem(SystemsNames.Crafting);
ItemsInventorySystem itemInv = (ItemsInventorySystem)player.GetSystem(SystemsNames.ItemsInventory);
SkillsSystem skills = (SkillsSystem)player.GetSystem(SystemsNames.Skills);

skills.AddSkill(new Skill(SkillsNames.CraftingSkill, 50));

Material material1 = new Material("Material1");
material1.SetMaterialProperties(1, 20, 1);
Material material2 = new Material("Material2");
material2.SetMaterialProperties(1, 20, 1);

List<Material> materials = new();
materials.Add(material1);
materials.Add(material2);

List<int> amount = new();
amount.Add(5);
amount.Add(3);

CraftingRecipe recipe = new CraftingRecipe("Gloves", PeaceOfGear.GearType.GLOVES, materials, amount);

Console.WriteLine("Recipe1 difficulty: " + recipe._RecipeDifficulty);

inv.AddNewMaterial(material1);
inv.AddNewMaterial(material2);

inv.AddMaterialsAmount(material1, 20);
inv.AddMaterialsAmount(material2, 20);

crafting.CraftItem(recipe);

Console.WriteLine(itemInv.ToString());

























