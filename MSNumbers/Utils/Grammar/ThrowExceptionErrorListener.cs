using Antlr4.Runtime;

namespace MSNumbers.Utils.Grammar;

public class ThrowExceptionErrorListener : BaseErrorListener, IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
{
    public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine,
        string msg, RecognitionException e)
    {
        throw new FormulaSyntaxException(charPositionInLine);
    }

    public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
        string msg, RecognitionException e)
    {
        throw new FormulaSyntaxException(charPositionInLine);
    }
}