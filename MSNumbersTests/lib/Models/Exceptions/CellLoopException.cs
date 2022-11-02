namespace MSNumbers.Models.Exceptions;

public class CellLoopException : CellException
{
    public CellLoopException() {}
    public CellLoopException(string message) : base(message) {}
}