using System.Text.RegularExpressions;

namespace MSNumbers.Models;

public static class Table
{
    public static string Name { get; private set; }
    public static string Path { get; private set; }
    public static int Rows { get; private set; }
    public static int Columns { get; private set;  }

    private static Dictionary<(int, int), Cell> _cells;

    public static void CreateBlank()
    {
        Name    = "Нова Таблиця";
        Path    = string.Empty;
        Rows    = 0;
        Columns = 0;
        _cells  = new Dictionary<(int, int), Cell>();
        
        for (int i = 0; i < 15; ++i)
        {
            AddColumn();
            AddRow();
        }
    }

    private static void AddColumn()
    {
        for (int r = 0; r < Rows; ++r)
        {
            _cells.Add((r, Columns), new Cell());
        }
        ++Columns;
    }

    private static void AddRow()
    {
        for (int c = 0; c < Columns; ++c)
        {
            _cells.Add((Rows, c), new Cell());
        }
        ++Rows;
    }

    public static string GetCell(int row, int column)
    {
        return _cells[(row, column)].GetValue();
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