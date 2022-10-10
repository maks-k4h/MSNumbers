using System.Data;
using Math = System.Math;

namespace MSNumbers.Utils.Grammar;

public class GrammarVisitor : SomeGrammarBaseVisitor<double>
{
    public override double VisitLine(SomeGrammarParser.LineContext context)
    {
        return VisitSum(context.sum());
    }

    public override double VisitSum(SomeGrammarParser.SumContext context)
    {
        if (context.ChildCount == 1)
            return VisitAddend(context.addend());
        
        if (context.ChildCount == 3)
        {
            if (context.children[1].ToString() == "+")
            {
                return VisitAddend(context.addend()) + VisitSum(context.sum());
            }
            else if (context.children[1].ToString() == "-")
            {
                return VisitAddend(context.addend()) - VisitSum(context.sum());
            }
        }

        throw new SyntaxErrorException();
    }

    public override double VisitAddend(SomeGrammarParser.AddendContext context)
    {
        if (context.ChildCount == 1)
            return VisitMultiplier(context.multiplier());

        if (context.ChildCount == 3)
        {
            if (context.children[1].ToString() == "*")
                return VisitMultiplier(context.multiplier()) * VisitAddend(context.addend());
            
            if (context.children[1].ToString() == "/")
                return VisitMultiplier(context.multiplier()) / VisitAddend(context.addend());
        }

        throw new SyntaxErrorException();
    }

    public override double VisitMultiplier(SomeGrammarParser.MultiplierContext context)
    {
        if (context.ChildCount == 1)
            return VisitAtomic(context.atomic()[0]);

        if (context.ChildCount == 3)
            return Math.Pow(VisitAtomic(context.atomic()[0]), VisitAtomic(context.atomic()[1]));

        throw new SyntaxErrorException();
    }

    public override double VisitAtomic(SomeGrammarParser.AtomicContext context)
    {
        return VisitChildren(context);
    }

    public override double VisitEnclosed_sum(SomeGrammarParser.Enclosed_sumContext context)
    {
        return Visit(context.sum());
    }

    public override double VisitInc(SomeGrammarParser.IncContext context)
    {
        return Visit(context.sum()) + 1;
    }

    public override double VisitDec(SomeGrammarParser.DecContext context)
    {
        return Visit(context.sum()) - 1;
    }

    public override double VisitMax(SomeGrammarParser.MaxContext context)
    {
        return Math.Max(Visit(context.sum()[0]), Visit(context.sum()[1]));
    }

    public override double VisitMin(SomeGrammarParser.MinContext context)
    {
        return Math.Min(Visit(context.sum()[0]), Visit(context.sum()[1]));
    }

    public override double VisitCell(SomeGrammarParser.CellContext context)
    {
        throw new NotImplementedException("Cell linking is not implemented yet.");
        var cell = Models.Table.CellNameToNumbers(context.GetText());
        return double.Parse(Models.Table.GetCellResult(cell.Item1, cell.Item2));
    }

    public override double VisitFloat(SomeGrammarParser.FloatContext context)
    {
        var s = context.GetText();
        return double.Parse(s);
    }
}