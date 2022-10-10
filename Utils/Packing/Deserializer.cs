using MSNumbers.Models;

namespace MSNumbers.Utils.Packing;

public static class Deserializer
{
    public static void FromFile(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException();
        Deserialize(File.ReadAllText(path));
        Table.SetPath(path);
    }

    public static void Deserialize(string content)
    {
        Table.Clean();
        try
        {
            var splitContent = content.Split('\n');
            for (var row = 0; row < splitContent.Length; ++row)
            {
                if (splitContent[row].Trim().Length == 0)
                    break;
                
                var cellsContent = splitContent[row].Split(';');
                
                if (cellsContent.Length < Table.Columns)
                    break;
                
                // extending the table
                Table.AddRow();
                while (Table.Columns < cellsContent.Length)
                    Table.AddColumn();

                // filling newly created cells
                for (var col = 0; col < cellsContent.Length; ++col)
                {
                    var formula = cellsContent[col].Trim();
                    Table.SetCellFormula(row, col, formula);
                }
            }
        }
        catch (Exception e)
        {
            // TODO Change the error message
            // TODO don't forget to test opening damaged files before
            throw e;
        }
    }
}