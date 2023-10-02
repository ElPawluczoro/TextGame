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

        AddNewMaterialsToWorld(worldSettings, 12); //min 10
        AddNewLocationsToWorld(worldSettings, 2);
        

        return worldSettings;
    }

    public static void AddNewMaterialsToWorld(WorldSettings worldSettings, int amount)
    {
        Random random = new Random();
        string newMaterialName = GenerateMaterialName();

        int materialsPerLevel = amount / 5;

        int targetLevel = 1;
        int changeTarget = 0;

        for (int i = 0; i < amount; i++)
        {
            while (worldSettings.ContainsNameInWorld(newMaterialName, WorldSettings.WorldEntity.MATERIAL))
            {
                newMaterialName = GenerateMaterialName();   
            }

            Material newMaterial;
            do
            {
                newMaterial = targetLevel <= 5
                    ? GenerateNewMaterial(newMaterialName, targetLevel)
                    : GenerateNewMaterial(newMaterialName);
                worldSettings.AddMaterial(newMaterial);
            } while (!CompareMaterialWithWorldMaterials(worldSettings, newMaterial));
            
            changeTarget++;
            if (changeTarget == materialsPerLevel)
            {
                changeTarget = 0;
                targetLevel += 1;
            }
        }
    }

    private static Material GenerateNewMaterial(string newMaterialName, int targetLevel)
    {
        Random random = new();
        Material newMaterial = new Material(newMaterialName);
        int level = targetLevel; //(hardness / 10 + magic) / 4; //max should be 5
        int hardness = random.Next(1, 100);
        int magic = random.Next(1, 10);
        while ((hardness + magic) / 4 > targetLevel)
        {
            if (magic == 1 || random.Next(1, 10) > 1)
            {
                hardness -= 2;
            }
            else
            {
                magic -= 1;
            }
        }

        while ((hardness + magic) / 4 < targetLevel)
        {
            if (magic == 10 || random.Next(1, 10) > 1)
            {
                hardness += 2;
            }
            else
            {
                magic += 1;
            }
        }
        
        newMaterial.SetMaterialProperties(level, hardness, magic);
        return newMaterial;
    }
    
    private static Material GenerateNewMaterial(string newMaterialName)
    {
        Random random = new();
        Material newMaterial = new Material(newMaterialName);
        int hardness = random.Next(1, 100);
        int magic = random.Next(1, 10); 
        int level = (hardness / 10 + magic) / 4; //max should be 5

        newMaterial.SetMaterialProperties(level, hardness, magic);
        return newMaterial;
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

    private static bool CompareMaterialWithWorldMaterials(WorldSettings world, Material material)
    {
        foreach (Material m in world.GetMaterialsInWorld())
        {
            if (Material.CompareMaterials(material, m)) return true;
        }

        return false;
    }
    
    
    
}



































