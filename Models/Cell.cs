using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using Antlr4.Runtime;
using MSNumbers.Models.Exceptions;
using MSNumbers.Utils.Grammar;

namespace MSNumbers.Models;

public class Cell : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private const int Precision = 5;
    
    private string _formula = "";
    // Extra field for data binding
    private FormulaResultPackage _value;
    private string _stringValue;
    
    // List of dependent cells (after current cell is updated, those must be visited too)
    private List<Cell> _children = new List<Cell>();

    public FormulaResultPackage Value
    {
        get => _value;
        private set
        {
            // remove old parents.
            // Explanation:
            // We actually say "Hey you, my old parents, now I have new 
            // value, so I don't depend on you from now on. You'd better  
            // forget about me and don't bother me every time you are 
            // updated or so."
            RemoveParents();
            
            _value = value;
            SetParents();
        }
    }

    public string StringValue
    {
        get => _stringValue;
        set
        {
            _stringValue = value;
            RaisePropertyChanged();
        }
    }

    public Cell()
    {
        Value = new FormulaResultPackage();
    }
    
    private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public void SetFormula(string formula)
    {
        var temp = _formula;
        try
        {
            _formula = formula.Trim();

            // calculating result
            CalculateResult();

            UpdateChildren();
        }
        catch (Exception)
        {
            // Rolling back to previous formula
            _formula = temp;
            CalculateResult(); // TODO: check if it's always correct
            throw;
        }
    }

    private void RemoveParents()
    {
        if (Value == null) return;
        foreach (var parent in Value.Dependencies)
        {
            Table.GetCell(parent.Item1, parent.Item2).RemoveChild(this);
        }
    }

    private void CalculateResult()
    {
        if (_formula.Length > 0 && _formula[0] == '=')
        {
            try
            {
                var inputStream = new AntlrInputStream(_formula[1..]);
                var lexer = new SomeGrammarLexer(inputStream);
                var commonTokenStream = new CommonTokenStream(lexer);
                var parser = new SomeGrammarParser(commonTokenStream);
                var context = parser.line();
                var visitor = new GrammarVisitor();

                Value = visitor.Visit(context);
                
                // setting string value needed for data binding
                StringValue = Math.Round(Value.Result, Precision).ToString();
            }
            catch (CellAccessException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Не вдається застосувати формулу, перевірте її правильність.");
            }
        }
        else
        {
            // DANGER: do not set empty string: maui doesn't get on with it:
            // ghost values were observed.
            StringValue = _formula.Length > 0? _formula : " ";
            Value = new FormulaResultPackage();
        }
    }

    private void SetParents()
    {
        foreach (var cellId in Value.Dependencies)
        {
            Table.GetCell(cellId.Item1, cellId.Item2).AddChild(this);
        }
    } 
    
    private void UpdateChildren()
    {
        // do not use foreach since the collection is modified
        for (var i = 0; i < _children.Count; ++i)
        {
            _children[i].CalculateResult(); 
            _children[i].UpdateChildren();
        }
    }

    public string GetFormula()
    {
        return _formula;
    }

    private void AddChild(Cell cell)
    {
        if (!_children.Contains(cell))
            _children.Add((cell));
    }

    private void RemoveChild(Cell cell)
    {
        _children.Remove(cell);
    }
}