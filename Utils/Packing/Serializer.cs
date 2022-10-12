using MSNumbers.Models;

namespace MSNumbers.Utils.Packing;

public static class Serializer
{
    public const char ColumnDeliminator = ';';
    public const char RowDeliminator = '\n';
    
    public static void ToFile(string path)
    {
        File.WriteAllText(path, Serialize());
    }

    private static string Serialize()
    {
        var res = "";

        for (var row = 0; row < Table.Rows; ++row)
        {
            for (var col = 0; col < Table.Columns; ++col)
            {
                res += Table.GetCellFormula(row, col);
                if (col != Table.Columns - 1) 
                    res += ColumnDeliminator;
            }
            if (row != Table.Rows - 1) 
                res += RowDeliminator;
        }
        
        return res;
    }
}