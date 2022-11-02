namespace MSNumbers.Models.Exceptions;

public class CellAccessException : CellException
{
    public CellAccessException() {}
    public CellAccessException(string message) : base (message) {}
}