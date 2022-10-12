namespace MSNumbers.Utils.Grammar;

public class FormulaSyntaxException : Exception
{
    public int Position { get; }
    
    public FormulaSyntaxException(string message) : base(message) {}

    public FormulaSyntaxException(string message, int position) : base(message)
    {
        Position = position;
    }

    public FormulaSyntaxException(int position)
    {
        Position = position;
    }
}