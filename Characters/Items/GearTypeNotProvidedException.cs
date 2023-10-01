namespace TextGame.Characters.Items;

public class GearTypeNotProvidedException : Exception
{
    public GearTypeNotProvidedException()
    {
        Console.WriteLine("Gear not provided exception");
    }
}