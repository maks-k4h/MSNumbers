using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MSNumbers.Utils.Grammar;

namespace MSNumbersTests;

public class GrammarTest
{
    [Fact]
    public void BinaryOperations()
    {
        Assert.True(false);
    }

    [Fact]
    public void IncAndDecFunctions()
    {
        Assert.True(false);
    }

    [Fact]
    public void MaxAndMinFunctions()
    {
        Assert.True(false);
    }

    [Fact]
    public void Brackets()
    {
        Assert.True(false);
    }

    [Fact]
    public void IgnoreWhitespace()
    {
        Assert.True(false);
    }

    [Fact]
    public void WholeNumbers()
    {
        Assert.True(false);
    }

    [Fact]
    public void FloatingPointNumbers()
    {
        Assert.True(false);
    }
    
    [Fact]
    public void ExceptionsOnGrammarMistakes()
    {
        // incorrect number representation
        
        // incorrect cell address
        
        // incorrect operations
        
        // incorrect functions
        
        // plain text
        
        // skipping brackets
        
        // incorrect operation combinations
        
        Assert.True(false);
    }

    [Fact]
    public void SpecificArithmeticOperations()
    {
        // division by zero
        
        // powers
        
        Assert.True(false);
    }

    [Fact]
    public void NonExistingCellAccess()
    {
        Assert.True(false);
    }

    [Fact]
    public void CellAccess()
    {
        Assert.True(false);
    }


    private FormulaResultPackage Calculate(string formula)
    {
        var lexer = new SomeGrammarLexer(new AntlrInputStream(formula));
        var commonTokenStream = new CommonTokenStream(lexer);
        var parser = new SomeGrammarParser(commonTokenStream);
        var visitor = new SomeGrammarVisitor();

        // removing default listeners and setting custom ones
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ThrowExceptionErrorListener());
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ThrowExceptionErrorListener());

        IParseTree context = parser.line();
        var result = visitor.Visit(context);
        
        return result;
    }
}