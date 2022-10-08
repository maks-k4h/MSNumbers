using System.Text.RegularExpressions;

namespace MSNumbers.Models;

public class Cell
{
    private string _formula = "";
    
    public string SetFormula(string formula)
    {
        // TODO get rid of one-character-debug-message
        if (formula.Length ==1)
            throw new Exception("Your formula has one character (DEBUG)!");
        _formula = formula;
        return GetResult();
    }

    public string GetResult()
    {
        return _formula;
    }

    public string GetFormula()
    {
        return _formula;
    }
}