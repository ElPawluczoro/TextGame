using TextGame.Characters.Items;
using TextGame.Crafting;
using TextGame.Exceptions;

// ReSharper disable StringLiteralTypo

namespace TextGame.World;

public class WorldGenerator
{
    private static readonly string[] locationPrefixes =
                                            {
                                                "Egn", "Afo", "Ego", "Vonv", "Sel",
                                                "Me", "Ge", "Qu", "Si", "So", "Hack",
                                                "Ve", "Nab", "Gal", "Reo", "La", 
                                                "S"
                                            };

    private static readonly string[] locationSuffixes =
                                            {
                                                "far", "han", "dyn", "lees", "kirk",
                                                "ije", "ill", "ke", "eat", "ago",
                                                "all", "kney", "sirth", "vi", "ibyl"
                                            };

    private static readonly string[] materialPrefixes =
                                            {
                                                "Ax", "On", "I", "Cop", "dia",
                                                "Ga", "Sylph", "Ox", "Cy", "Rex",
                                                "Rax"
                                            };

    private static readonly string[] materialSuffixes = 
                                            {
                                                "ron", "per", "mond", "lena", "lan",
                                                "lon", "lona", "ran", "rin", "rond" 
                                            };

    private static readonly string[] gearPrefixesLevel1 =
                                            {
                                                "", "Bandit ", "Milita ", "Thug ", "Hunter ", "Archer "
                                            };
    
    private static readonly string[] gearPrefixesLevel2 =
                                            {
                                                "Adventurer ", "Veteran ", "Soldier ", "Guard ", "Mercenary ", 
                                                "Swords man ", "Warrior ", "Barbarian "
                                            };

    private static readonly string[] gearPrefixesLevel3 =
                                            {
                                                "Veteran adventurer ", "Capitan ", "Monster slyer ", "Bandit boss ",
                                                "Knight ", "Halberdier ", "Kings guard "
                                            };

    private static readonly string[] gearPrefixesLevel4 =
                                            {
                                                "Holy knight ", "Dark knight ", "General ", "Paladin ",
                                                "Legendary adventurer ", "Dragon slayer ", "Ancient warrior "
                                            };
    private static readonly string[] gearPrefixesLevel5 =
                                            {
                                                "Dark lord ", "Messanger of hell ", "Messanger of haven ",
                                                "Old gods ", "Dark prophet ", "Prophet of haven "
                                            };

    private static readonly string[] gearSuffixesHelmet =
                                            {
                                                "Barbute", "Close Helmet", "coventry Sallet", "Enclosed Helmet", 
                                                "Falling Buffe", "Frog-mouth Helm", "Great Helm", "Kettle Hat",
                                                "Sallet", "Visor"
                                            };
    
    private static readonly string[] gearSuffixesBodyArmor =
                                            {
                                                "Brigandine", "Hauberk", "Byrnie", "Cuirass", "Plackart", "Faulds",
                                                "Culet"
                                            };
    private static readonly string[] gearSuffixesGloves =
                                            {
                                                "Gauntlets", "Gloves", "Full Gauntlets" 
                                            };
    private static readonly string[] gearSuffixesPants=
                                            {
                                                "Greaves", "Cuisses", "Legs armor", "Full plate pants" 
                                            };
    private static readonly string[] gearSuffixesBoots =
                                            {
                                                "Boots", "Sabatons", "Full Boots", "Sollerets", "Plate Shoes", "Shoes"
                                            };

    private static readonly string[] gearSuffixesOneHandWeapon =
                                            {
                                                "Viking Sword", "Arming Sword", "Flachion", "Lange Messer", "Katzbalger",
                                                "Battle axe", "Viking axe", "War axe", "Mace", "Flanged Mace", "Sabre",
                                                "War hammer", "Short spear"
                                            };
    private static readonly string[] gearSuffixesTwoHandedWeapon =
                                            {
                                                "Flail", "Morning star", "Hammer", "Axe", "Estoc", "Longsword", "Messer",
                                                "Zweihander", "Halberd", "Pike", "Military Fork", "Long spear", 
                                                "War Scythe", "Voulge", "Swordstaff", "Spetum", "Spvnya", "Ranseur",
                                                "Partisan", "Lucerne hammer", "Lochaber Axe", "Glaive", "Bardiche"
                                            };

    public static WorldSettings GenerateWorld()
    {
        WorldSettings worldSettings = new WorldSettings("TestWorld");

        AddNewMaterialsToWorld(worldSettings, 48); //min 10
        Console.WriteLine("Generating world 1/3");
        AddNewLocationsToWorld(worldSettings, 50);
        Console.WriteLine("Generating world 2/3");
        GenerateCraftingRecipes(worldSettings);
        Console.WriteLine("Generating world 3/3");
        

        return worldSettings;
    }
    
    //Location generation
    public static string GenerateLocationName()
    {
        Random random = new Random();
        return locationPrefixes[random.Next(0, locationPrefixes.Length)] +
               locationSuffixes[random.Next(0, locationSuffixes.Length)];
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
    //Material generation
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
    
        public static string GenerateMaterialName()
    {
        Random random = new Random();
        return materialPrefixes[random.Next(0, materialPrefixes.Length)] +
               materialSuffixes[random.Next(0, materialSuffixes.Length)];
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
    
    //Recipe generation
    private static string GetNameSuffix(PeaceOfGear.GearType gearType)
    {
        List<string> suffixesList;
        switch (gearType)
        {
            case PeaceOfGear.GearType.HELMET:
                suffixesList = gearSuffixesHelmet.ToList();
                break;
            case PeaceOfGear.GearType.BODY_ARMOR:
                suffixesList = gearSuffixesBodyArmor.ToList();
                break;
            case PeaceOfGear.GearType.GLOVES:
                suffixesList = gearSuffixesGloves.ToList();
                break;
            case PeaceOfGear.GearType.PANTS:
                suffixesList = gearSuffixesPants.ToList();
                break;
            case PeaceOfGear.GearType.BOOTS:
                suffixesList = gearSuffixesBoots.ToList();
                break;
            case PeaceOfGear.GearType.ONE_HAND_WEAPON:
                suffixesList = gearSuffixesOneHandWeapon.ToList();
                break;
            case PeaceOfGear.GearType.TWO_HAND_WEAPON:
                suffixesList = gearSuffixesTwoHandedWeapon.ToList();
                break;
            default:
                suffixesList = new();
                break;
        }

        Random random = new();
        return suffixesList[random.Next(0, suffixesList.Count)];

    }

    private static string GetNamePrefix(int level)
    {
        List<string> prefixesList;
        switch (level)
        {
            case 1:
                prefixesList = gearPrefixesLevel1.ToList();
                break;
            case 2:
                prefixesList = gearPrefixesLevel2.ToList();
                break;
            case 3:
                prefixesList = gearPrefixesLevel3.ToList();
                break;
            case 4:
                prefixesList = gearPrefixesLevel4.ToList();
                break;
            case 5:
                prefixesList = gearPrefixesLevel5.ToList();
                break;
            default:
                prefixesList = new();
                break;
        }

        Random random = new();
        return prefixesList[random.Next(0, prefixesList.Count)];
    }
    
    private static string GenerateCraftingRecipeBaseName(WorldSettings worldSettings, Material material, PeaceOfGear.GearType gearType)
    {
        string baseName = "";
        int counter = 0;
        do
        {
            counter++;
            baseName = GetNamePrefix(material._MaterialLevel) + GetNameSuffix(gearType);
            if (counter == 500)
            {
                throw new FailedToGenerateNameException();
            }
        } while (worldSettings.ContainsNameInWorld(baseName, WorldSettings.WorldEntity.RECIPE));
            
        return baseName;
    }

    private static List<Material> GenerateNeededMaterials(WorldSettings world, Material mainMaterial)
    {
        Random random = new();
        List<Material> neededMaterials = new();
        List<Material> sameLevelMaterials = new();
        foreach (Material material in world.GetMaterialsInWorld())
        {
            if(material._MaterialName == mainMaterial._MaterialName) continue;
            if (material._MaterialLevel == mainMaterial._MaterialLevel)
            {
                sameLevelMaterials.Add(material);
            }
        }
        
        neededMaterials.Add(mainMaterial);
        neededMaterials.Add(sameLevelMaterials[random.Next(0, sameLevelMaterials.Count)]);
        return neededMaterials;
    }

    private static List<int> GenerateNeededMaterialsAmount()
    {
        Random random = new();
        List<int> materialsAmount = new();
        materialsAmount.Add(random.Next(5, 10));
        materialsAmount.Add(random.Next(1, 4));
        return materialsAmount;
    }

    private static CraftingRecipe GenerateCraftingRecipe
        (WorldSettings worldSettings, Material mainMaterial, PeaceOfGear.GearType gearType)
    {
        string baseName = GenerateCraftingRecipeBaseName(worldSettings, mainMaterial, gearType);
        List<Material> neededMaterials = GenerateNeededMaterials(worldSettings, mainMaterial);
        List<int> neededMaterialsAmount = GenerateNeededMaterialsAmount();
        return new CraftingRecipe(baseName, gearType, neededMaterials, neededMaterialsAmount);
    }

    private static void GenerateCraftingRecipes(WorldSettings worldSettings)
    {
        foreach (Material material in worldSettings.GetMaterialsInWorld())
        {
            foreach (PeaceOfGear.GearType gearType in PeaceOfGear._GearTypes)
            {
                for (int i = 0; i < 2; i++)
                {
                    worldSettings.AddCraftingRecipe(GenerateCraftingRecipe(worldSettings, material, gearType));   
                }
            }
        }

        Random random = new();
        
        for (int i = 0; i < worldSettings.GetMaterialsInWorld().Count * 2; i++)
        {
            var materialsInWorld = worldSettings.GetMaterialsInWorld();
            worldSettings.AddCraftingRecipe(GenerateCraftingRecipe(worldSettings,
                materialsInWorld[random.Next(0, materialsInWorld.Count)],
                PeaceOfGear._GearTypes[random.Next(0, PeaceOfGear._GearTypes.Length)]));
        }
    }
    
}



































