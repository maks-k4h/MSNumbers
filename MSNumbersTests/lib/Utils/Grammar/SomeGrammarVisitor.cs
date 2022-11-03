using System.Data;
using Math = System.Math;
namespace MSNumbers.Utils.Grammar;

public class SomeGrammarVisitor : SomeGrammarBaseVisitor<FormulaResultPackage>
{
    public override FormulaResultPackage VisitLine(SomeGrammarParser.LineContext context)
    {
        return VisitSum(context.sum());
    }

    public override FormulaResultPackage VisitSum(SomeGrammarParser.SumContext context)
    {
        var res = VisitAddend(context.addend()[0]);
        for (int i = 1; i < context.addend().Length; ++i)
        {
            var a = VisitAddend(context.addend()[i]);
            
            res.AddDependencies(a);
            
            if (context.children[2 * i - 1].ToString() == "+")
                res.Result += a.Result;
            else if (context.children[2 * i - 1].ToString() == "-")
                res.Result -= a.Result;
            else
                throw new SyntaxErrorException();
        }

        return res;
    }

    public override FormulaResultPackage VisitAddend(SomeGrammarParser.AddendContext context)
    {
        var res = VisitMultiplier(context.multiplier()[0]);
        for (int i = 1; i < context.multiplier().Length; ++i)
        {
            var a = VisitMultiplier(context.multiplier()[i]);
            
            res.AddDependencies(a);
            
            if (context.children[2 * i - 1].ToString() == "*")
                res.Result *= a.Result;
            else if (context.children[2 * i - 1].ToString() == "/")
                res.Result /= a.Result;
            else
                throw new SyntaxErrorException();
        }

        return res;
    }

    public override FormulaResultPackage VisitMultiplier(SomeGrammarParser.MultiplierContext context)
    {
        var res = VisitAtomic(context.atomic()[0]);
        for (int i = 1; i < context.atomic().Length; ++i)
        {
            var a = VisitAtomic(context.atomic()[i]);
            
            res.AddDependencies(a);
            
            if (context.children[2 * i - 1].ToString() == "^")
                res.Result = Double.Pow(res.Result, a.Result);
            else
                throw new SyntaxErrorException();
        }

        return res;
    }

    public override FormulaResultPackage VisitAtomic(SomeGrammarParser.AtomicContext context)
    {
        return VisitChildren(context) ?? new FormulaResultPackage();
    }

    public override FormulaResultPackage VisitEnclosed_sum(SomeGrammarParser.Enclosed_sumContext context)
    {
        return Visit(context.sum());
    }

    public override FormulaResultPackage VisitInc(SomeGrammarParser.IncContext context)
    {
        var res = Visit(context.sum());
        ++res.Result;
        return res;
    }

    public override FormulaResultPackage VisitDec(SomeGrammarParser.DecContext context)
    {
        var res = Visit(context.sum());
        --res.Result;
        return res;
    }

    public override FormulaResultPackage VisitMax(SomeGrammarParser.MaxContext context)
    {
        var a = Visit(context.sum()[0]);
        var b = Visit(context.sum()[1]);
        var res = new FormulaResultPackage { Result = Math.Max(a.Result, b.Result) };
        res.AddDependencies(a);
        res.AddDependencies(b);
        return res;
    }

    public override FormulaResultPackage VisitMin(SomeGrammarParser.MinContext context)
    {
        var a = Visit(context.sum()[0]);
        var b = Visit(context.sum()[1]);
        var res = new FormulaResultPackage { Result = Math.Min(a.Result, b.Result) };
        res.AddDependencies(a);
        res.AddDependencies(b);
        return res;
    }

    public override FormulaResultPackage VisitCell(SomeGrammarParser.CellContext context)
    {
        var cell = Models.Table.CellNameToNumbers(context.GetText());
        var res = new FormulaResultPackage
        {
            Result = Models.Table.GetCellNumericalResult(cell.Item1, cell.Item2)
        };
        res.AddDependency(cell);
        return res;
    }

    public override FormulaResultPackage VisitFloat(SomeGrammarParser.FloatContext context)
    {
        var s = context.GetText();
        try
        {
            return new FormulaResultPackage { Result = double.Parse(s) };
        }
        catch (Exception)
        {
           // ignored 
        }
        
        try
        {
            return new FormulaResultPackage { Result = double.Parse(s.Replace('.', ',')) };
        }
        catch
        {
            // ignored
        }
        
        try
        {
            return new FormulaResultPackage { Result = double.Parse(s.Replace(',', '.')) };
        }
        catch
        {
            // ignored
        }
        
        throw new Exception($"Error while parsing double from {s}");
    }
}