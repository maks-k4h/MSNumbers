namespace MSNumbers.Utils.Grammar;

public class FormulaResultPackage
{
    public readonly List<(int, int)> Dependencies = new List<(int, int)>();
    public double Result = 0;

    public void AddDependency((int, int) item)
    {
        Dependencies.Add(item);
    }

    public void AddDependencies(FormulaResultPackage that)
    {
        this.Dependencies.AddRange(that.Dependencies);
    }
}