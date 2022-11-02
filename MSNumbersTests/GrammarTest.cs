using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MSNumbers.Models;
using MSNumbers.Utils.Grammar;

namespace MSNumbersTests;

public class GrammarTest
{
    [Fact]
    public void BinaryOperations()
    {
        FormulaResultPackage r;
        
        // +
        r = Calculate("1+1");
        Assert.Empty(r.Dependencies);
        Assert.Equal(2, r.Result);
        
        r = Calculate("1+2+3");
        Assert.Equal(6, r.Result);
        
        r = Calculate("0+0+0+0");
        Assert.Empty(r.Dependencies);
        Assert.Equal(0, r.Result);
        
        r = Calculate("10000000000");
        Assert.Equal(1e10, r.Result);
        
        // -
        r = Calculate("1-1");
        Assert.Empty(r.Dependencies);
        Assert.Equal(0, r.Result);
        
        r = Calculate("5-1-1-1-1");
        Assert.Empty(r.Dependencies);
        Assert.Equal(1, r.Result);
        
        // *
        r = Calculate("5*4");
        Assert.Empty(r.Dependencies);
        Assert.Equal(20,r.Result);

        r = Calculate("1*2*3*2*1");
        Assert.Empty(r.Dependencies);
        Assert.Equal(1*2*3*2*1, r.Result);
        
        // /
        r = Calculate("10/2");
        Assert.Empty(r.Dependencies);
        Assert.Equal(5, r.Result);

        r = Calculate("24/6/2");
        Assert.Empty(r.Dependencies);
        Assert.Equal(2, r.Result);
        
        // ^
        r = Calculate("10^2");
        Assert.Empty(r.Dependencies);
        Assert.Equal(100, r.Result);

        // combinations
        r = Calculate("2*3+2^2-3+12/4");
        Assert.Empty(r.Dependencies);
        Assert.Equal(2*3+2^2-3+12/4, r.Result);
        
        r = Calculate("1-1+1-1+1-1+1");
        Assert.Empty(r.Dependencies);
        Assert.Equal(1, r.Result);
    }

    [Fact]
    public void IncAndDecFunctions()
    {
        FormulaResultPackage r;
        
        r = Calculate("inc(0)");
        Assert.Empty(r.Dependencies);
        Assert.Equal(1, r.Result);
        
        r = Calculate("dec(0)");
        Assert.Empty(r.Dependencies);
        Assert.Equal(-1, r.Result);
        
        r = Calculate("inc(inc(inc(inc(0))))");
        Assert.Empty(r.Dependencies);
        Assert.Equal(4, r.Result);
        
        r = Calculate("dec(dec(dec(dec(0))))");
        Assert.Empty(r.Dependencies);
        Assert.Equal(-4, r.Result);
        
        r = Calculate("inc(dec(inc(dec(0))))");
        Assert.Empty(r.Dependencies);
        Assert.Equal(0, r.Result);
    }

    [Fact]
    public void MaxAndMinFunctions()
    {
        FormulaResultPackage r;
        
        r = Calculate("max(0,0)");
        Assert.Empty(r.Dependencies);
        Assert.Equal(0, r.Result);
        
        r = Calculate("max(1+1,0*1)");
        Assert.Empty(r.Dependencies);
        Assert.Equal(2, r.Result);
        
        r = Calculate("max(1+1,2*2^2)");
        Assert.Empty(r.Dependencies);
        Assert.Equal(8, r.Result);
        
        r = Calculate("min(2,5-1)");
        Assert.Empty(r.Dependencies);
        Assert.Equal(2, r.Result);
        
        r = Calculate("min(33,2*2^2)");
        Assert.Empty(r.Dependencies);
        Assert.Equal(8, r.Result);
        
        r = Calculate("max(min(33,16),min(32,12))");
        Assert.Empty(r.Dependencies);
        Assert.Equal(16, r.Result);
    }

    [Fact]
    public void Brackets()
    {
        FormulaResultPackage r;
        
        r = Calculate("3-(1-1)");
        Assert.Empty(r.Dependencies);
        Assert.NotEqual(Calculate("3-1-1").Result, r.Result);

        r = Calculate("3^min(5,3+1)");
        Assert.Equal(81, r.Result);

        r = Calculate("(18+6/3-11^2+12^2)");
        Assert.Equal(43, r.Result);
    }

    [Fact]
    public void IgnoreWhitespaces()
    {
        FormulaResultPackage r;
        
        r = Calculate("(18\t\t +  6/3- 11  ^2+  12^ 2)  ");
        Assert.Equal(43, r.Result);
        
        r = Calculate("max( min(  33 ,  16),min(32,12   ) )");
        Assert.Equal(16, r.Result);
        
        
        r = Calculate(" 2 *3\t+2\t\t^2 -3 +12/\t4");
        Assert.Equal(2*3+2^2-3+12/4, r.Result);
    }

    [Fact]
    public void WholeNumbers()
    {
        FormulaResultPackage r;

        r = Calculate("012345");
        Assert.Empty(r.Dependencies);
        Assert.Equal(12345, r.Result);
        
        r = Calculate("100");
        Assert.Empty(r.Dependencies);
        Assert.Equal(100, r.Result);
        
        r = Calculate("1-00001");
        Assert.Empty(r.Dependencies);
        Assert.Equal(0, r.Result);

        try
        {
            r = Calculate("0x1111");
            Assert.Fail($"0x1111 calculated with value of {r.Result}.");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            r = Calculate("a10b2");
            Assert.Fail($"a10b2 calculated with value of {r.Result}.");
        }
        catch (Exception)
        {
            // ignored
        }
    }

    [Fact]
    public void FloatingPointNumbers()
    {
        FormulaResultPackage r;
        
        r = Calculate("0.01");
        Assert.Empty(r.Dependencies);
        Assert.Equal(0.01, r.Result);
        
        r = Calculate(".01");
        Assert.Empty(r.Dependencies);
        Assert.Equal(0.01, r.Result);
        
        r = Calculate("12.33");
        Assert.Empty(r.Dependencies);
        Assert.Equal(12.33, r.Result);

        try
        {
            r = Calculate("12.-33");
            Assert.Fail($"12.-33 calculated with value of {r.Result}.");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            r = Calculate("1.1.1");
            Assert.Fail($"1.1.1 calculated with value of {r.Result}.");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            r = Calculate("1...1");
            Assert.Fail($"1...1 calculated with value of {r.Result}.");
        }
        catch (Exception)
        {
            // ignored
        }
    }
    
    [Fact]
    public void ExceptionsOnGrammarMistakes()
    {
        FormulaResultPackage r;

        // incorrect cell address
        Table.CreateBlank();
        r = Calculate("A1");
        
        try
        {
            r = Calculate("A0");
            Assert.Fail("Cell A0 had been accessed.");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            r = Calculate("AAA0");
            Assert.Fail("Cell AAA0 had been accessed.");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            r = Calculate("A0.0");
            Assert.Fail("Cell A0.0 had been accessed.");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            r = Calculate("A0B0");
            Assert.Fail("Cell A0B0 had been accessed.");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            r = Calculate("A");
            Assert.Fail("Cell A had been accessed.");
        }
        catch (Exception)
        {
            // ignored
        }

        // incorrect operations
        
        try
        {
            var s = "2 /// 2";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = "2 /* 2";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = "2++-2";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = "2 ^^^ 2";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = "2 . 2";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = "2 times 2";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        // incorrect functions
        try
        {
            var s = "maax(24, 33)";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = "iinc(21)";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }

        r = Calculate("max((2), 13)");
        Assert.Equal(r.Result, 13);
        try
        {
            var s = "max(2,3";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = "min((21, 18))";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        // plain text
        try
        {
            var s = "Hello, Dolly!";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = ".";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = "/";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }

        r = Calculate("\t\t\t");
        if (r is not null)
            Assert.Equal(r.Result, 0);
        try
        {
            var s = "1\t\t1";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        // skipping brackets
        r = Calculate("(((1.1)))");
        Assert.Equal(r.Result, 1.1);
        try
        {
            var s = "(((1.1))";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        // skipping brackets
        r = Calculate("(((1.1)))");
        Assert.Equal(r.Result, 1.1);
        try
        {
            var s = "(max(3,3)))";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = "(1(";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            var s = ")max(min(2,2),1)(";
            r = Calculate(s);
            Assert.Fail($"{s} had been processed with result {r.Result}");
        }
        catch (Exception)
        {
            // ignored
        }
    }

    [Fact]
    public void SpecificArithmeticOperations()
    {
        FormulaResultPackage r;
        
        // division by zero
        r = Calculate("1/0");
        Assert.Equal(double.PositiveInfinity, r.Result);
        
        r = Calculate("-1/0");
        Assert.Equal(double.NegativeInfinity, r.Result);
        
        r = Calculate("0/0");
        Assert.Equal(double.NaN, r.Result);
        
        // powers
        r = Calculate("0^0");
        Assert.Equal(1, r.Result);
        
        r = Calculate("0^(0-1)");
        Assert.Equal(double.PositiveInfinity, r.Result);
        
        r = Calculate("4^.5");
        Assert.Equal(2, r.Result);
        
        r = Calculate("(0-4)^.5");
        Assert.Equal(double.NaN, r.Result);
    }

    [Fact]
    public void NonExistingCellAccess()
    {
        Table.CreateBlank();
        FormulaResultPackage r;

        try
        {
            r = Calculate("A0");
            Assert.Fail("Cell A0 had been accessed!");
        }
        catch
        {
            // ignored
        }
        
        r = Calculate($"A{Table.Columns}");
        Assert.Equal(0, r.Result);
        try
        {
            var s = $"=A{Table.Rows + 1}";
            r = Calculate(s);
            Assert.Fail($"Cell {s} had been accessed!");
        }
        catch
        {
            // ignored
        }
        
        Table.SetCellFormula(Table.Rows-1, Table.Columns - 1, "=3");
        r = Calculate($"{Table.NumberToAlphabeticSystem(Table.Columns - 1)}{Table.Rows}");
        Assert.Equal(3, r.Result);
        try
        {
            var s = $"{Table.NumberToAlphabeticSystem(Table.Columns)}{Table.Rows}";
            r = Calculate(s);
            Assert.Fail($"Cell {s} had been accessed!");
        }
        catch
        {
            // ignored
        }
    }

    [Fact]
    public void CellAccess()
    {
        Table.CreateBlank();
        FormulaResultPackage r;
        
        r = Calculate("A1");
        Assert.Equal(0, r.Result);
        Assert.NotEmpty(r.Dependencies);
        Assert.Equal(Table.GetCell(r.Dependencies[0]), Table.GetCell(0, 0));
        
        Table.SetCellFormula(0,0,"=12");
        r = Calculate("A1");
        Assert.Equal(12, r.Result);
        
        Table.SetCellFormula(0, 0, "=5");
        Table.SetCellFormula(0, 1, "=3");
        Table.SetCellFormula(0, 2, "=1");
        Table.SetCellFormula(0, 3, "=99");
        
        r = Calculate("max(A1 - B1, C1+D1)");
        Assert.Equal(100, r.Result);
        Assert.Equal(4, r.Dependencies.Count);
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