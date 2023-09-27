﻿using TextGame.World;

WorldSettings worldSettings = WorldGenerator.GenerateWorld();

List<Location> locations = worldSettings.GetLocationsInWorld();
foreach (Location location in locations)
{
    Console.WriteLine(location.ToString());
}


