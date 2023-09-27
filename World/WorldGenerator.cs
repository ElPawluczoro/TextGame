using TextGame.Crafting;

namespace TextGame.World;

public class WorldGenerator
{
    public static string[] locationPrefixes = { "Egn", "Afo", "Ego" };
    public static string[] locationSuffixes = { "far", "han", "dyn" };

    public static string GenerateLocationName()
    {
        Random random = new Random();
        return locationPrefixes[random.Next(0, locationPrefixes.Length - 1)] +
               locationSuffixes[random.Next(0, locationSuffixes.Length - 1)];
    }

    public static WorldSettings GenerateWorld()
    {
        WorldSettings worldSettings = new WorldSettings("TestWorld");

        Material material1 = new Material("TestMaterial");
        
        Location newLocation = new Location(GenerateLocationName(), true);
        newLocation.AddMaterial(material1);
        
        worldSettings.AddLocation(newLocation);

        return worldSettings;
    }
}