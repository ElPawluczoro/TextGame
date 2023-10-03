namespace TextGame.Exceptions;

public class FailedToGenerateNameException : Exception
{
    public FailedToGenerateNameException()
    {
        Console.WriteLine("Failed to generate name exception\n" +
                          "probably you are trying to generate to much names");
    }
}