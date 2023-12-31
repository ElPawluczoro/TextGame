﻿using TextGame.Characters.Items;
using TextGame.Crafting;
using TextGame.GeneralMethods;

namespace TextGame.Characters.CharactersSystems;

public class CraftingSystem : ACharacterSystem
{
    public CraftingSystem()
    {
        systemName = SystemsNames.Crafting;
        requiredSystems.Add(new MaterialsInventorySystem());
        requiredSystems.Add(new ItemsInventorySystem());
    }

    private bool IsMaterialsEnough(CraftingRecipe recipe, MaterialsInventorySystem inventory)
    {
        for (int i = 0; i < recipe.GetNeededMaterials().Count; i++)
        {
            int amount = recipe.GetNeededMaterialsAmount()[i];
            Material material = recipe.GetNeededMaterials()[i];
            if (!inventory.IsMaterialEnough(material, amount))
            {
                Console.WriteLine("Not enough " + material._MaterialName);
                return false;
            }
        }
        return true;
    }
    
    private void SpendMaterials(CraftingRecipe recipe, MaterialsInventorySystem inventory)
    {
        for (int i = 0; i < recipe.GetNeededMaterials().Count; i++)
        {
            int amount = recipe.GetNeededMaterialsAmount()[i];
            Material material = recipe.GetNeededMaterials()[i];
            inventory.SpendMaterialsAmount(material, amount);
        }
    }

    private string namePrefix = "";

    private void RollForGearRarityIncrease(PeaceOfGear gear)
    {
        Random random = new();

        int fromBasicChance = 50; //its % (max 100)
        int fromRareChance = 45; //its % (max 100)
        int fromLegendaryChance = 25; //its % (max 100)
        while (gear._GearRarity != PeaceOfGear.GearRarity.MYTHIC)
        {
            switch (gear._GearRarity)
            {
                case PeaceOfGear.GearRarity.BASIC:
                    if (random.Next(1, 100) <= fromBasicChance)
                    {
                        gear.SetGearRarity(PeaceOfGear.GearRarity.RARE);
                        break;
                    }
                    return;
                case PeaceOfGear.GearRarity.RARE:
                    if (random.Next(1, 100) <= fromRareChance)
                    {
                        gear.SetGearRarity(PeaceOfGear.GearRarity.LEGENDARY);
                        break;
                    }
                    return;
                case PeaceOfGear.GearRarity.LEGENDARY:
                    if (random.Next(1, 100) <= fromLegendaryChance)
                    {
                        gear.SetGearRarity(PeaceOfGear.GearRarity.MYTHIC);
                        break;
                    }
                    return;
            }    
        }
    }

    private GearStats.Stats RollForStat(PeaceOfGear gear)
    {
        Random random = new();
        
        List<GearStats.Stats> statsPossibleList = GearStats.statsPossible.ToList();
        if (gear._GearType == PeaceOfGear.GearType.ONE_HAND_WEAPON ||
            gear._GearType == PeaceOfGear.GearType.TWO_HAND_WEAPON)
        {
            statsPossibleList.Remove(GearStats.Stats.ARMOR);
        }
        else
        {
            statsPossibleList.Remove(GearStats.Stats.DAMAGE);
        }
        GearStats.RemoveAlreadyUsedStatsFromList(gear, statsPossibleList);

        return statsPossibleList[random.Next(0, statsPossibleList.Count)];
    }

    private void SetPeaceOfGearStat(PeaceOfGear gear, int times, int minRoll, int maxRoll)
    {
        Random random = new();
        GearStats.Stats stat;
        for (int i = 0; i < times; i++)
        {
            stat = RollForStat(gear);
            int statValue = random.Next(minRoll, maxRoll);
            SetStat(gear, stat, statValue);
            
        }
    }

    private void SetStat(PeaceOfGear gear, GearStats.Stats stat, int value)
    {
        switch (stat)
        {
            case GearStats.Stats.VITALITY:
                gear.SetVitality(value);
                break;
            case GearStats.Stats.STRENGTH:
                gear.SetStrength(value);
                break;
            case GearStats.Stats.DEXTERITY:
                gear.SetDexterity(value);
                break;
            case GearStats.Stats.INTELLIGENCE:
                gear.SetIntelligence(value);
                break;
            case GearStats.Stats.ARMOR:
                gear.SetArmor(value);
                break;
            case GearStats.Stats.DAMAGE:
                gear.SetDamage(value);
                break;
        }
    }

    private void SetPeaceOfGearStatsByRarity(PeaceOfGear gear, CraftingRecipe recipe)
    {
        Random random = new();
        if (gear._GearType == PeaceOfGear.GearType.ONE_HAND_WEAPON ||
            gear._GearType == PeaceOfGear.GearType.TWO_HAND_WEAPON)
        {
            SetStat(gear, GearStats.Stats.DAMAGE,
                random.Next(recipe.MinArmorDamageRoll, recipe.MaxArmorDamageRoll));
        }
        else
        {
            SetStat(gear, GearStats.Stats.ARMOR, 
                random.Next(recipe.MinArmorDamageRoll, recipe.MaxArmorDamageRoll));
        }

        int min = recipe.MinStatRoll;
        int max = recipe.MaxStatRoll;
        
        switch (gear._GearRarity)
        {
            case PeaceOfGear.GearRarity.BASIC:
                break;
            case PeaceOfGear.GearRarity.RARE: 
                SetPeaceOfGearStat(gear, 2, min, max);
                break;
            case PeaceOfGear.GearRarity.LEGENDARY: 
                SetPeaceOfGearStat(gear, 3, min, max);
                break;
            case PeaceOfGear.GearRarity.MYTHIC: 
                SetPeaceOfGearStat(gear, 4, min, max);
                break;
        }
    }
    
    private void SetPeaceOfGearStats(PeaceOfGear gear, CraftingRecipe recipe)
    {
        RollForGearRarityIncrease(gear);
        SetPeaceOfGearStatsByRarity(gear, recipe);
    }

    private string GetPeaceOfGearNameFromRarity(PeaceOfGear gear)
    {
        switch (gear._GearRarity)
        {
            case PeaceOfGear.GearRarity.BASIC:
                return "";
            case PeaceOfGear.GearRarity.RARE:
                return "Rare ";
            case PeaceOfGear.GearRarity.LEGENDARY:
                return "Legendary ";
            case PeaceOfGear.GearRarity.MYTHIC:
                return "Mythic ";
            default:
                return "";
        }
    }

    private GearStats.Stats GetHighestStat(PeaceOfGear gear)
    {
        GearStats.Stats highestStat = GearStats.Stats.ARMOR;
        int highestStatValue = 0;
        if (gear._Vitality > highestStatValue)
        {
            highestStat = GearStats.Stats.VITALITY;
            highestStatValue = gear._Vitality;
        }
        if (gear._Strength > highestStatValue)
        {
            highestStat = GearStats.Stats.STRENGTH;
            highestStatValue = gear._Strength;
        }
        if (gear._Dexterity > highestStatValue)
        {
            highestStat = GearStats.Stats.DEXTERITY;
            highestStatValue = gear._Dexterity;
        }
        if (gear._Intelligence > highestStatValue)
        {
            highestStat = GearStats.Stats.INTELLIGENCE;
            highestStatValue = gear._Intelligence;
        }

        return highestStat;
    }
    
    private string GetPeaceOfGearNameFromStats(PeaceOfGear gear)
    {
        switch (GetHighestStat(gear))
        {
            case GearStats.Stats.VITALITY:
                return " of vitality";
            case GearStats.Stats.STRENGTH:
                return " of strength";
            case GearStats.Stats.DEXTERITY:
                return " of dexterity";
            case GearStats.Stats.INTELLIGENCE:
                return " of intelligence";
            default:
                return "";
        }
    }

    private int GetSumOfStats(PeaceOfGear gear)
    {
        return gear._Vitality + gear._Strength + gear._Dexterity + gear._Intelligence + gear._Armor;
    }

    private void SetItemValue(PeaceOfGear gear)
    {
        int value = 0;
        switch (gear._GearRarity)
        {
            case PeaceOfGear.GearRarity.BASIC:
                value += 10;
                break;
            case PeaceOfGear.GearRarity.RARE:
                value += 30;
                break;
            case PeaceOfGear.GearRarity.LEGENDARY:
                value += 60;
                break;
            case PeaceOfGear.GearRarity.MYTHIC:
                value += 150;
                break;
        }

        value += GetSumOfStats(gear) * 3;
        gear.SetValue(value);
    }

    private void SetGearType(PeaceOfGear gear, CraftingRecipe recipe)
    {
        gear.SetGearType(recipe._GearType);
    }

    private bool IsCraftingSkillEnough(CraftingRecipe recipe)
    {
        SkillsSystem skills = (SkillsSystem)character.GetSystem(SystemsNames.Skills);
        int skillLevel = skills.GetSkill(SkillsNames.CraftingSkill)._SkillLevel;
        if (skillLevel >= recipe._RecipeDifficulty)
        {
            return true;
        }

        return false;
    }
    
    public void CraftItem(CraftingRecipe recipe)
    {
        MaterialsInventorySystem inventory =
            (MaterialsInventorySystem)character.GetSystem(SystemsNames.MaterialsInventory);
        if (!IsCraftingSkillEnough(recipe))
        {
            Console.WriteLine("This recipe is too hard");
            return;
        }

        if (!IsMaterialsEnough(recipe, inventory))
        {
            Console.WriteLine("Character don't have enough materials");
            return;
        }
        
        SpendMaterials(recipe, inventory);

        Item newItem = new PeaceOfGear("PeaceOfGear");
        
        if (newItem._ItemType == ItemType.PEACE_OF_GEAR)
        {
            PeaceOfGear newPeaceOfGear = (PeaceOfGear)newItem;
            SetGearType(newPeaceOfGear, recipe);
            SetPeaceOfGearStats(newPeaceOfGear, recipe);
            SetItemValue(newPeaceOfGear);
            
            string itemName = GetPeaceOfGearNameFromRarity(newPeaceOfGear);
            itemName += recipe._BaseName;
            itemName += GetPeaceOfGearNameFromStats(newPeaceOfGear);
            newPeaceOfGear.SetName(itemName);
            
            newItem = newPeaceOfGear;
        }

        ItemsInventorySystem itemsInventory = (ItemsInventorySystem)character.GetSystem(SystemsNames.ItemsInventory);
        itemsInventory.AddItemToInventory(newItem);

    }

    public override string ToString()
    {
        return "";
    }
}