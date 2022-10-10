using System.Data;
using Antlr4.Runtime;
using MSNumbers.Utils.Grammar;

namespace MSNumbers.Models;

public class Cell
{
    private const int Precision = 5;
    
    private string _formula = "";
    
    public string SetFormula(string formula)
    {
        var temp = _formula;
        try
        {
            _formula = formula.Trim();
            var res = GetResult();
            return res;
        }
        catch (Exception)
        {
            _formula = temp;
            throw;
        }
    }

    public string GetResult()
    {
        if (_formula.Length == 0)
            return "";
        
        if (_formula[0] == '=')
        {
            try
            {
                var inputStream = new AntlrInputStream(_formula[1..]);
                var lexer = new SomeGrammarLexer(inputStream);
                var commonTokenStream = new CommonTokenStream(lexer);
                var parser = new SomeGrammarParser(commonTokenStream);
                var context = parser.line();
                var visitor = new GrammarVisitor();

                return Math.Round(visitor.Visit(context), Precision).ToString();
            }
            catch (Exception)
            {
                throw;//new Exception("Не вдається застосувати формулу, перевірте її правильність.");
            }
        }

        return _formula;
    }

    public string GetFormula()
    {
        return _formula;
    }
}