namespace MSNumbers.Utils.Packing;

public class DamagedFileException : Exception
{
    public DamagedFileException() {}
    public DamagedFileException(string message) : base(message) {}
}