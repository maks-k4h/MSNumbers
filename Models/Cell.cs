namespace MSNumbers.Models;

public class Cell
{
    private string _formula;

    public string SetFormula(string formula)
    {
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