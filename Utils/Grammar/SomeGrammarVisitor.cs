using System.Data;
using Math = System.Math;

namespace MSNumbers.Utils.Grammar;

public class GrammarVisitor : SomeGrammarBaseVisitor<FormulaResultPackage>
{
    public override FormulaResultPackage VisitLine(SomeGrammarParser.LineContext context)
    {
        return VisitSum(context.sum());
    }

    public override FormulaResultPackage VisitSum(SomeGrammarParser.SumContext context)
    {
        if (context.ChildCount == 1)
            return VisitAddend(context.addend());
        
        if (context.ChildCount == 3)
        {
            var a = Visit(context.addend());
            var b = Visit(context.sum());
            var res = new FormulaResultPackage();
            res.Dependencies.AddRange(a.Dependencies);
            res.Dependencies.AddRange(b.Dependencies);
            
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

        throw new SyntaxErrorException();
    }

    public override FormulaResultPackage VisitAddend(SomeGrammarParser.AddendContext context)
    {
        if (context.ChildCount == 1)
            return VisitMultiplier(context.multiplier());

        if (context.ChildCount == 3)
        {
            var a = Visit(context.multiplier());
            var b = Visit(context.addend());
            var res = new FormulaResultPackage();
            res.Dependencies.AddRange(a.Dependencies);
            res.Dependencies.AddRange(b.Dependencies);
            
            if (context.children[1].ToString() == "*")
                res.Result = a.Result * b.Result;
            
            if (context.children[1].ToString() == "/")
                res.Result = a.Result / b.Result;
            
            return res;
        }

        throw new SyntaxErrorException();
    }

    public override FormulaResultPackage VisitMultiplier(SomeGrammarParser.MultiplierContext context)
    {
        if (context.ChildCount == 1)
            return VisitAtomic(context.atomic()[0]);

        if (context.ChildCount == 3)
        {
            var a = Visit(context.atomic()[0]);
            var b = Visit(context.atomic()[1]);
            var res = new FormulaResultPackage { Result = Math.Pow(a.Result, b.Result) };
            res.Dependencies.AddRange(a.Dependencies);
            res.Dependencies.AddRange(b.Dependencies);
            return res;
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
        res.Dependencies.AddRange(a.Dependencies);
        res.Dependencies.AddRange(b.Dependencies);
        return res;
    }

    public override FormulaResultPackage VisitMin(SomeGrammarParser.MinContext context)
    {
        var a = Visit(context.sum()[0]);
        var b = Visit(context.sum()[1]);
        var res = new FormulaResultPackage { Result = Math.Min(a.Result, b.Result) };
        res.Dependencies.AddRange(a.Dependencies);
        res.Dependencies.AddRange(b.Dependencies);
        return res;
    }

    public override FormulaResultPackage VisitCell(SomeGrammarParser.CellContext context)
    {
        var cell = Models.Table.CellNameToNumbers(context.GetText());
        var res = new FormulaResultPackage
        {
            Result = Models.Table.GetCellNumericalResult(cell.Item1, cell.Item2)
        };
        res.Dependencies.Add(cell);
        return res;
    }

    public override FormulaResultPackage VisitFloat(SomeGrammarParser.FloatContext context)
    {
        var s = context.GetText();
        return new FormulaResultPackage { Result = double.Parse(s) };
    }
}