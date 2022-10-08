using System.Text.RegularExpressions;
using MSNumbers.Utils;

namespace MSNumbers.Models;

public static class Table
{
    public const int MaxColumns = 25;
    public static string Name { get; private set; }
    public static int Rows { get; private set; }
    public static int Columns { get; private set;  }

    private static Dictionary<(int, int), Cell> _cells;
    private static string _path;

    public static void Clean()
    {
        Name    = "Нова Таблиця";
        _path   = string.Empty;
        Rows    = 0;
        Columns = 0;
        
        _cells?.Clear();
        _cells = new Dictionary<(int, int), Cell>();
    }
    
    public static void CreateBlank()
    {
        Name    = "Нова Таблиця";
        _path   = string.Empty;
        Rows    = 0;
        Columns = 0;
        
        _cells?.Clear();
        _cells = new Dictionary<(int, int), Cell>();

        for (int i = 0; i < 20; ++i)
        {
            AddColumn();
            AddRow();
        }
    }
    
    public static void Save()
    {
        Serializer.ToFile(_path);
    }

    public static bool HasPath()
    {
        return _path.Length != 0;
    }

    public static string GetPath()
    {
        return _path;
    }

    public static void SetPath(string path)
    {
        _path = path;
        Name = path;
    }

    public static void AddColumn()
    {
        if (Columns == MaxColumns)
            throw new Exception("Max number of columns reached!");
        for (int r = 0; r < Rows; ++r)
        {
            _cells.Add((r, Columns), new Cell());
            
        }
        ++Columns;
    }

    public static void AddRow()
    {
        for (int c = 0; c < Columns; ++c)
        {
            _cells.Add((Rows, c), new Cell());
        }
        ++Rows;
    }

    public static string GetCellResult(int row, int column)
    {
        return _cells[(row, column)].GetResult();
    }
    
    public static string GetCellFormula(int row, int column)
    {
        return _cells[(row, column)].GetFormula();
    }

    // Returns the result of the formula applied.
    // If the formula is incorrect, proper exception is thrown
    // and the previous value is left.
    public static string SetCellFormula(int row, int column, string formula)
    {
        return _cells[(row, column)].SetFormula(formula);
    }

    public static (int, int) CellNameToNumbers(string name)
    {
        if (!Regex.IsMatch(name, "[A-Z][0-9]+"))
            throw new Exception("Wrong Cell Name");
        var col = name[0] - 'A';
        var row = int.Parse(name[1..]); 
        return (row, col);
    }

    public static string NumbersToCellName(int row, int col)
    {
        return $"{(char)('A' + col)}{row + 1}";
    }
}