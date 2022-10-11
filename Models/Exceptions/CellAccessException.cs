namespace MSNumbers.Models.Exceptions;

public class CellAccessException : Exception
{
    public CellAccessException() {}
    public CellAccessException(string message) : base (message) {}
}