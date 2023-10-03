using TextGame.Crafting;

namespace TextGame.World;

public class WorldSettings
{
    private string worldName;
    private List<Material> materialsAvaiableInWorld = new();
    private List<Location> locationsInWorld = new();
    private List<CraftingRecipe> craftingRecipesInWorld = new();

    public WorldSettings(string worldName)
    {
        this.worldName = worldName;
    }

    public void AddMaterial(Material material)
    {
        if (material._MaterialDifficulty == 0 || material._MaterialHardness == 0 || material._MaterialLevel == 0) return;
        materialsAvaiableInWorld.Add(material);
    }

    public List<Material> GetMaterialsInWorld()
    {
        return materialsAvaiableInWorld;
    }

    public void AddLocation(Location location)
    {
        locationsInWorld.Add(location);
    }

    public List<Location> GetLocationsInWorld()
    {
        return locationsInWorld;
    }

    public void AddCraftingRecipe(CraftingRecipe recipe)
    {
        craftingRecipesInWorld.Add(recipe);
    }

    public List<CraftingRecipe> GetCraftingRecipesInWorld()
    {
        return craftingRecipesInWorld;
    }

    public bool ContainsNameInWorld(string name, WorldEntity worldEntity)
    {
        if (worldEntity == WorldEntity.MATERIAL)
        {
            foreach (Material material in materialsAvaiableInWorld)
            {
                if (material._MaterialName == name) return true;
            }
            return false;   
        }
        else if (worldEntity == WorldEntity.LOCATION)
        {
            foreach (Location location in locationsInWorld)
            {
                if (location.LocationName == name) return true;
            }
            return false;
        }
        else
        {
            foreach (CraftingRecipe recipe in craftingRecipesInWorld)
            {
                if (recipe._BaseName == name) return true;
            }
            return false;
        }
    }


    public enum WorldEntity
    {
        MATERIAL, LOCATION, RECIPE
    }
}