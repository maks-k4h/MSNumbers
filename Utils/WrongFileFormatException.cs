namespace MSNumbers.Utils;

public class WrongFileFormatException : Exception
{
    public WrongFileFormatException()
    { }
    public WrongFileFormatException(string message) : base(message)
    { }
}