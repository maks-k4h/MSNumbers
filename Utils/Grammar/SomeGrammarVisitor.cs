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
        {
            return VisitAddend(context.addend());
        }
        else if (context.ChildCount == 3)
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
        {
            return VisitMultiplier(context.multiplier());
        }
        else if (context.ChildCount == 3)
        {
            if (context.children[1].ToString() == "*")
            {
                return VisitMultiplier(context.multiplier()) * VisitAddend(context.addend());
            }
            else if (context.children[1].ToString() == "/")
            {
                return VisitMultiplier(context.multiplier()) / VisitAddend(context.addend());
            }
        }

        throw new SyntaxErrorException();
    }

    public override double VisitMultiplier(SomeGrammarParser.MultiplierContext context)
    {
        if (context.ChildCount == 1)
        {
            return VisitAtomic(context.atomic()[0]);
        }
        else if (context.ChildCount == 3)
        {
            return Math.Pow(VisitAtomic(context.atomic()[0]), VisitAtomic(context.atomic()[1]));
        }

        throw new SyntaxErrorException();
    }

    public override double VisitAtomic(SomeGrammarParser.AtomicContext context)
    {
        if (context.ChildCount == 1)
        {
            return VisitFloat(context.@float());
        }
        else
        {
            var v1 = VisitSum(context.sum()[0]);
            switch (context.children[0].GetText())
            {
                case "(":
                    return v1;
                case "inc":
                    return v1 + 1;
                case "dec":
                    return v1 - 1;
                case "max":
                    return Math.Max(v1, VisitSum(context.sum()[1]));
                case "min":
                    return Math.Min(v1, VisitSum(context.sum()[1]));
            }
        }

        throw new SyntaxErrorException();
    }

    public override double VisitFloat(SomeGrammarParser.FloatContext context)
    {
        var s = context.GetText();
        return double.Parse(s);
    }
}