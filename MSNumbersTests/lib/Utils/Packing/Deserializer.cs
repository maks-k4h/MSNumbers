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

    private static void Deserialize(string content)
    {
        Table.Clean();
        try
        {
            var splitContent = content.Split(Serializer.RowDelimiter);
            
            // extending the table
            while (Table.Rows < splitContent.Length)
                Table.AddRow();
            
            for (var row = 0; row < splitContent.Length; ++row)
            {
                var cellsContent = splitContent[row].Split(Serializer.ColumnDelimiter);
                
                if (cellsContent.Length < Table.Columns)
                    break;
                
                // extending the table
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
        catch (Exception)
        {
            throw new DamagedFileException("Файл пошкодженно!");
        }
    }
}