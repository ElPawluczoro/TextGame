using TextGame.Crafting;
// ReSharper disable StringLiteralTypo

namespace TextGame.World;

public class WorldGenerator
{
    public static string[] locationPrefixes = { "Egn", "Afo", "Ego" };
    public static string[] locationSuffixes = { "far", "han", "dyn" };
    
    public static string[] materialPrefixes = { "Ax", "On", "I", "Cop", "dia", "Ga" };
    public static string[] materialSuffixes = { "ron", "per", "mond", "lena" };

    public static string GenerateLocationName()
    {
        Random random = new Random();
        return locationPrefixes[random.Next(0, locationPrefixes.Length)] +
               locationSuffixes[random.Next(0, locationSuffixes.Length)];
    }

    public static string GenerateMaterialName()
    {
        Random random = new Random();
        return materialPrefixes[random.Next(0, materialPrefixes.Length)] +
               materialSuffixes[random.Next(0, materialSuffixes.Length)];
    }

    public static WorldSettings GenerateWorld()
    {
        WorldSettings worldSettings = new WorldSettings("TestWorld");

        AddNewMaterialsToWorld(worldSettings, 3);
        AddNewLocationsToWorld(worldSettings, 2);
        

        return worldSettings;
    }

    public static void AddNewMaterialsToWorld(WorldSettings worldSettings, int amount)
    {
        Random random = new Random();
        string newMaterialName = GenerateMaterialName();
        for (int i = 0; i < amount; i++)
        {
            while (worldSettings.ContainsNameInWorld(newMaterialName, WorldSettings.WorldEntity.MATERIAL))
            {
                newMaterialName = GenerateMaterialName();   
            }

            Material newMaterial = new Material(newMaterialName);
            int hardness = random.Next(1, 100);
            int difficulty = random.Next(1, 10);
            int level = (hardness / 10 + difficulty) / 4 ; //max should be 5
            newMaterial.SetMaterialProperties(level, hardness, difficulty);
            worldSettings.AddMaterial(newMaterial);
            

        }
    }

    public static void AddNewLocationsToWorld(WorldSettings worldSettings, int amount)
    {
        Random random = new Random();
        string newLocationName = GenerateLocationName();
        for (int i = 0; i < amount; i++)
        {
            while (worldSettings.ContainsNameInWorld(newLocationName, WorldSettings.WorldEntity.LOCATION))
            {
                newLocationName = GenerateLocationName();   
            }

            Location newLocation = new Location(newLocationName, true);
            AddMaterialsToLocation(worldSettings, newLocation, random.Next(2, 4));
            worldSettings.AddLocation(newLocation);
        }
    }

    public static void AddMaterialsToLocation(WorldSettings worldSettings,Location location, int amount)
    {
        Random random = new Random();
        var materialsInWorld = worldSettings.GetMaterialsInWorld();
        Material materialToAdd = materialsInWorld[random.Next(0, materialsInWorld.Count)];
        for (int i = 0; i < amount; i++)
        {
            while (location.ContainsMaterial(materialToAdd))
            {
                materialToAdd = materialsInWorld[random.Next(0, materialsInWorld.Count)];
            }
            location.AddMaterial(materialToAdd);
        }
    }
    
}



































