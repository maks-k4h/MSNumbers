using System.Text.RegularExpressions;
using MSNumbers.Models.Exceptions;
using MSNumbers.Utils.Packing;

namespace MSNumbers.Models;

public static class Table
{
    private const int MaxColumns = 1024;
    private const int MaxRows    = 1024;
    
    public static string Name { get; private set; }
    public static int Rows { get; private set; }
    public static int Columns { get; private set;  }
    
    private static string _path;

    // cells pool
    private static Dictionary<(int, int), Cell> _cells;

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
        Clean();

        for (var i = 0; i < 10; ++i)
            AddColumn();
        for (var i = 0; i < 10; ++i)
            AddRow();
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
        if (Columns >= MaxColumns)
            throw new Exception("Досягнено максимальну кількість стовпчиків!");
        for (int r = 0; r < Rows; ++r)
        {
            _cells.Add((r, Columns), new Cell());
        }
        ++Columns;
    }

    public static void AddRow()
    {
        if (Rows >= MaxRows)
            throw new Exception("Досягнено максимальну кількість рядків!");
        for (int c = 0; c < Columns; ++c)
        {
            _cells.Add((Rows, c), new Cell());
        }
        ++Rows;
    }

    public static string GetCellStringResult(int row, int column)
    {
        return GetCell(row, column).StringValue;
    }
    
    public static double GetCellNumericalResult(int row, int column)
    {
        return GetCell(row, column).NumericalValue;
    }
    
    public static string GetCellFormula(int row, int column)
    {
        return GetCell(row, column).GetFormula();
    }

    public static Cell GetCell(int row, int column)
    {
        try{
            return _cells[(row, column)];
        }
        catch (Exception)
        {
            throw new CellAccessException(
                $"Клітина {NumbersToCellName(row, column)} не може бути досягненою.");
        }
    }

    // Returns the result of the formula applied.
    // If the formula is incorrect, proper exception is thrown
    // and the previous value is left.
    public static void SetCellFormula(int row, int column, string formula)
    {
        GetCell(row, column).SetFormula(formula);
    }

    public static (int, int) CellNameToNumbers(string name)
    {
        name = name.ToUpper();
        
        if (!Regex.IsMatch(name, "[A-Z]+[0-9]+"))
            throw new CellAccessException("Некоректно вказана адреса клітини.");
        
        var col = 0;
        const int bs = 'Z' - 'A' + 1;
        var accumulator = 0;
        var p = 0;
        while (name[0] >= 'A')
        {
            col += accumulator;
            accumulator = accumulator == 0 ? bs : accumulator * bs;
            p = p * bs + name[0] - 'A';
            name = name[1..];
        }

        col += p;
        
        var row = int.Parse(name) - 1; 
        return (row, col);
    }

    public static string NumbersToCellName(int row, int col)
    {
        if (col < 0)
            throw new CellAccessException("Некоректно вказана адреса клітини.");
        return NumberToAlphabeticSystem(col) + (row + 1).ToString();
    }

    public static string NumbersToCellName((int, int) address)
    {
        return NumbersToCellName(address.Item1, address.Item2);
    }

    public static string NumberToAlphabeticSystem(int n)
    {
        if (n < 0)
            throw new CellAccessException("Некоректно вказана адреса клітини.");
        const int bs = 'Z' - 'A' + 1;

        string res = "";
        int k = 1;
        int accumulator = bs;
        while (n - accumulator >= 0)
        {
            n -= accumulator;
            accumulator *= bs;
            ++k;
        }

        for (int i = 0; i < k; ++i)
        {
            res = (char)('A' + n % bs) + res;
            n /= bs;
        }

        return res;
    }
}