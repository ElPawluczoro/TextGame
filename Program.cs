using TextGame.Characters.CharactersSystems;
using TextGame.Characters.Items;
using TextGame.Characters.PlayerCharacter;
using TextGame.Crafting;
using TextGame.GeneralMethods;
using TextGame.World;

//WorldSettings worldSettings = WorldGenerator.GenerateWorld();

Player player = new Player("Player");

WorldSettings world = WorldGenerator.GenerateWorld();

foreach (CraftingRecipe recipe in world.GetCraftingRecipesInWorld())
{
    Console.WriteLine(recipe.ToString());
}
























