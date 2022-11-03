using System.ComponentModel;
using System.Runtime.CompilerServices;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MSNumbers.Models.Exceptions;
using MSNumbers.Utils.Grammar;
using MSNumbers.Utils.Packing;
using Exception = System.Exception;
using Math = System.Math;

namespace MSNumbers.Models;

public class Cell : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private const int FloatingPointDisplayPrecision = 5;
    
    private string _formula = "";
    // Extra field for data binding
    private string _stringValue = "";
    private FormulaResultPackage _value;
    
    // List of dependent cells (after current cell is updated, those must be visited too)
    private List<Cell> _children = new();
    
    // Anti-looping variable
    private bool _involved;

    public string StringValue
    {
        get => _stringValue;
        set
        {
            _stringValue = value;
            RaisePropertyChanged();
        }
    }

    public double NumericalValue => Value.Result;

    private FormulaResultPackage Value
    {
        get => _value;
        set
        {
            // remove old parents.
            // Explanation:
            // We actually say "Hey you, my old parents. I no longer
            // need your updates, so don't bother me if something is
            // changed!"
            // RemoveParents();
            RemoveParents();
            
            _value = value;
            
            // setting connections or, informally, subscribing for 
            // parents' updates.
            SetParents();
        }
    }

    public Cell()
    {
        Value = new FormulaResultPackage();
    }

    ~Cell()
    {
        RemoveParents();
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

            // and update dependent cells or cells that are
            // subscribed to this
            UpdateChildren();
        }
        catch (Exception)
        {
            _formula = temp;
            throw;
        }
    }

    private void RemoveParents()
    {
        if (Value == null) return;
        try
        {
            foreach (var parent in Value.Dependencies)
            {
                Table.GetCell(parent).RemoveChild(this);
            }
        }
        catch (Exception) // Parent might already be deleted
        {
            //throw;
        }
    }
    
    
    private void CalculateResult()
    {
        if (_formula.Contains(Serializer.ColumnDelimiter) || _formula.Contains(Serializer.RowDelimiter))
            throw new Exception($"Формула не може містити '{Serializer.ColumnDelimiter}' !");
        
        if (_formula.Length > 0 && _formula[0] == '=')
        {
            try
            {
                // basic ANTLR tools initialization
                var lexer = new SomeGrammarLexer(new AntlrInputStream(_formula[1..]));
                var commonTokenStream = new CommonTokenStream(lexer);
                var parser = new SomeGrammarParser(commonTokenStream);
                var visitor = new SomeGrammarVisitor();

                // removing default listeners and setting custom ones
                lexer.RemoveErrorListeners();
                lexer.AddErrorListener(new ThrowExceptionErrorListener());
                parser.RemoveErrorListeners();
                parser.AddErrorListener(new ThrowExceptionErrorListener());

                IParseTree context = parser.line();
                var result = visitor.Visit(context);

                CheckForRecursion(result);
                
                Value = result;

                // setting string value needed for data binding
                StringValue = Math.Round(Value.Result, FloatingPointDisplayPrecision).ToString();
            }
            catch (FormulaSyntaxException e)
            {
                throw new Exception($"Синтаксична помилка на позиції {e.Position} " +
                                    $"(після '{_formula[e.Position]}')");
            }
            catch (CellException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception)
            {
                throw new Exception("Не вдається застосувати формулу, перевірте її правильність.");
            }
        }
        else
        {
            // DANGER: do not set to an empty string: maui doesn't get on with it:
            // ghost values appeared in cells that were previously emptied.
            StringValue = _formula.Length > 0? _formula : " ";
            Value = new FormulaResultPackage();
        }
    }

    private void SetParents()
    {
        foreach (var cellId in Value.Dependencies)
        {
            Table.GetCell(cellId).AddChild(this);
        }
    }
    
    private void UpdateChildren()
    {
        foreach (var child in _children)
        {
            
            child.CalculateResult();
            child.UpdateChildren();
        }
    }

    private void CheckForRecursion(FormulaResultPackage  package = null)
    {
        package ??= Value;

        if (_involved)
            throw new CellLoopException("Виявлено рекурсивне задання формули");

        try
        {
            _involved = true;
            foreach (var dependency in package.Dependencies)
            {
                Table.GetCell(dependency).CheckForRecursion();
            }
        }
        finally
        {
            _involved = false;
        }
    }

    public string GetFormula()
    {
        return _formula;
    }

    private void AddChild(Cell cell)
    {
        if (!_children.Contains(cell))
            _children.Add(cell);
    }

    private void RemoveChild(Cell cell)
    {
        _children = _children.Where(child => child != cell).ToList();
    }
}