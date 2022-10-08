namespace MSNumbers.Models;

public class Cell
{
    private string _formula;

    public string SetFormula(string formula)
    {
        return GetValue();
    }

    public string GetValue()
    {
        return "Value...";
    }

    public string GetFormula()
    {
        return _formula;
    }
}