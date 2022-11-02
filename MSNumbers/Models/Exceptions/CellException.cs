namespace MSNumbers.Models.Exceptions;

public class CellException : Exception
{
    public CellException() {}
    public CellException(string message) : base(message) {}
}