using TextGame.Crafting;

namespace TextGame.World;

public class WorldSettings
{
    private string worldName;
    private List<Material> materialsAvaiableInWorld = new List<Material>();
    private List<Location> locationsInWorld = new List<Location>();

    public WorldSettings(string worldName)
    {
        this.worldName = worldName;
    }

    public void AddMaterial(Material material)
    {
        if (material.MaterialDifficulty == 0 || material.MaterialHardness == 0 || material.MaterialLevel == 0) return;
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

    public bool ContainsNameInWorld(string name, WorldEntity worldEntity)
    {
        if (worldEntity == WorldEntity.MATERIAL)
        {
            foreach (Material material in materialsAvaiableInWorld)
            {
                if (material.MaterialName == name) return true;
            }
            return false;   
        }
        else
        {
            foreach (Location location in locationsInWorld)
            {
                if (location.LocationName == name) return true;
            }
            return false;
        }
    }


    public enum WorldEntity
    {
        MATERIAL, LOCATION
    }
}