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
        switch (context.ChildCount)
        {
            case 1:
                return VisitAddend(context.addend());
            case 3:
            {
                // TODO: implement operation overload instead of this mess
                var a = Visit(context.addend());
                var b = Visit(context.sum());
                var res = new FormulaResultPackage();
                res.AddDependencies(a);
                res.AddDependencies(b);
            
                if (context.children[1].ToString() == "+")
                {
                    res.Result = a.Result + b.Result;
                }
                else if (context.children[1].ToString() == "-")
                {
                    res.Result = a.Result - b.Result;
                }

                return res;
            }
        }
        
        throw new SyntaxErrorException();
    }

    public override FormulaResultPackage VisitAddend(SomeGrammarParser.AddendContext context)
    {
        switch (context.ChildCount)
        {
            case 1:
                return VisitMultiplier(context.multiplier());
            case 3:
            {
                var a = Visit(context.multiplier());
                var b = Visit(context.addend());
                var res = new FormulaResultPackage();
                res.AddDependencies(a);
                res.AddDependencies(b);
            
                if (context.children[1].ToString() == "*")
                    res.Result = a.Result * b.Result;
                else if (context.children[1].ToString() == "/")
                    res.Result = a.Result / b.Result;
            
                return res;
            }
        }
        
        throw new SyntaxErrorException();
    }

    public override FormulaResultPackage VisitMultiplier(SomeGrammarParser.MultiplierContext context)
    {
        switch (context.ChildCount)
        {
            case 1:
                return VisitAtomic(context.atomic()[0]);
            case 3:
            {
                var a = Visit(context.atomic()[0]);
                var b = Visit(context.atomic()[1]);
                var res = new FormulaResultPackage { Result = Math.Pow(a.Result, b.Result) };
                res.AddDependencies(a);
                res.AddDependencies(b);
                return res;
            }
        }
        throw new SyntaxErrorException();
    }

    public override FormulaResultPackage VisitAtomic(SomeGrammarParser.AtomicContext context)
    {
        return VisitChildren(context);
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
            throw new Exception($"Error while parsing double from {s}");
        }
    }
}