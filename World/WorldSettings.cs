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
    
}