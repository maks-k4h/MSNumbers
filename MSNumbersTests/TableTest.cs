using MSNumbers.Models;
using MSNumbers.Utils.Packing;

namespace MSNumbersTests;

public class TableTest
{
    [Fact]
    public void CleanTable()
    {
        Table.CreateBlank();
        Table.AddColumn();
        Table.AddRow();
        Table.AddRow();

        Table.Clean();
        Assert.Equal(0, Table.Rows);
        Assert.Equal(0, Table.Columns);
        Assert.Empty(Table.GetPath());
        Assert.False(Table.HasPath());
    }

    [Fact]
    public void CreateBlankTable()
    {
        Table.CreateBlank();
        Assert.NotEqual(0, Table.Rows);
        Assert.NotEqual(0, Table.Columns);
        Assert.Empty(Table.GetPath());
        Assert.False(Table.HasPath());
    }

    [Fact]
    public void AddressToNumberConversion()
    {
        try
        {
            var res = Table.CellNameToNumbers("A0");
            Assert.Fail("Got number representations of A0: " + res);
        }
        catch
        {
            // ignored
        }

        (int, int) r;

        r = Table.CellNameToNumbers("A1");
        Assert.Equal((0, 0), r);
        
        r = Table.CellNameToNumbers("Z100");
        Assert.Equal((99, 25), r);
        
        r = Table.CellNameToNumbers("AA100");
        Assert.Equal((99, 26), r);
        
        r = Table.CellNameToNumbers("ZZ100");
        Assert.Equal((99, 701), r);
        
        r = Table.CellNameToNumbers("AAA100");
        Assert.Equal((99, 702), r);
        
        r = Table.CellNameToNumbers("BCD92");   
        Assert.Equal((91, 702 + 1*26*26 + 2*26 + 3), r);
    }

    [Fact]
    public void NumberToAddressConversion()
    {
        try
        {
            var res = Table.NumberToAlphabeticSystem(-1);
            Assert.Fail("Converted -1 to Alphabetic System: " + res);
        }
        catch
        {
            // ignored
        }
        
        Assert.Equal("A", Table.NumberToAlphabeticSystem(0));
        Assert.Equal("AA", Table.NumberToAlphabeticSystem(26));
        Assert.Equal("ZZ", Table.NumberToAlphabeticSystem(701));
        Assert.Equal("AAA", Table.NumberToAlphabeticSystem(702));
        Assert.Equal("BCD", Table.NumberToAlphabeticSystem(702 + 1*26*26 + 2*26 + 3));
    }

    [Fact]
    public void SettingTablePath()
    {
        Table.CreateBlank();
        
        var fileName = "name29341.csv";
        
        Table.SetPath(fileName);
        Assert.Equal(fileName, Table.GetPath());
        Assert.True(Table.HasPath());
        
        if (File.Exists(fileName))
            File.Delete(fileName);
    }

    [Fact]
    public void SavingAndLoadingTable()
    {
        Table.CreateBlank();

        var fileName = "name29341.csv";
        
        if (File.Exists(fileName))
            File.Delete(fileName);
        
        Table.SetPath(fileName);
        Assert.Equal(fileName, Table.GetPath());
        Assert.True(Table.HasPath());
        
        Table.SetCellFormula(0, 0, "=12 + b1");
        Table.SetCellFormula(0, 1, "=9");
        Assert.Equal(21, Table.GetCellNumericalResult(0,0));
        Assert.Equal(9, Table.GetCellNumericalResult(0,1));
        
        Table.Save();
        
        Table.Clean();
        
        Deserializer.FromFile(fileName);
        
        Assert.Equal(21, Table.GetCellNumericalResult(0,0));
        Assert.Equal(9, Table.GetCellNumericalResult(0,1));

        if (File.Exists(fileName))
            File.Delete(fileName);
    }

    [Fact]
    public void LoadingDamagedFile()
    {
        var fileName = "name29341.csv";
        
        if (File.Exists(fileName))
            File.Delete(fileName);
        
        File.WriteAllText(fileName, "\t\t\tnth");

        Table.Clean();
        try
        {
            Deserializer.FromFile(fileName);
            Assert.Fail("Damaged file loaded.");
        }
        catch
        {
            // ignore
        }

        var rd = Serializer.RowDelimiter;
        var cd = Serializer.ColumnDelimiter;
        File.WriteAllText(fileName, $"b1{cd}a1{cd}{rd}"); // recursion in file

        Table.Clean();
        try
        {
            Deserializer.FromFile(fileName);
            Assert.Fail("Damaged file loaded.");
        }
        catch
        {
            // ignore
        }
    }

    [Fact]
    public void AddingColumnsAndRows()
    {
        Table.Clean();
        Assert.Equal(0, Table.Rows);
        Assert.Equal(0, Table.Columns);
        
        Table.AddRow();
        Table.AddColumn();
        Assert.Equal(1, Table.Rows);
        Assert.Equal(1, Table.Columns);
        
        Assert.Equal(0, Table.GetCellNumericalResult(0, 0));
        
        Table.AddRow();
        Table.AddColumn();
        Assert.Equal(2, Table.Rows);
        Assert.Equal(2, Table.Columns);
        
        Assert.Equal(0, Table.GetCellNumericalResult(0, 1));
        Assert.Equal(0, Table.GetCellNumericalResult(1, 0));
        Assert.Equal(0, Table.GetCellNumericalResult(1, 1));

        for (int i = 0; i < 8; ++i)
        {
            Table.AddColumn();
            Table.AddRow();
        }
        
        Assert.Equal(10, Table.Rows);
        Assert.Equal(10, Table.Columns);

        for (int i = 0; i < 10; ++i)
        {
            for (int j = 0; j < 10; ++j)
            {
                Assert.Equal(0, Table.GetCellNumericalResult(i, j));
            }
        }
    }

    [Fact]
    public void RowsAndColumnsNumberOverflow()
    {
        Table.Clean();
        
        for (int i = 0; i < Table.MaxColumns; ++i)
            Table.AddColumn();
        
        Assert.Equal(Table.MaxColumns, Table.Columns);
        Assert.Equal(0, Table.Rows);
        try
        {
            Table.AddColumn();
            Assert.Fail("Column overflow ignored!");
        }
        catch
        {
            // ignored
        }
        Assert.Equal(Table.MaxColumns, Table.Columns);
        Assert.Equal(0, Table.Rows);
        
        for (int i = 0; i < Table.MaxRows; ++i)
            Table.AddRow();
        
        Assert.Equal(Table.MaxColumns, Table.Columns);
        Assert.Equal(Table.MaxRows, Table.Rows);
        try
        {
            Table.AddRow();
            Assert.Fail("Row overflow ignored!");
        }
        catch
        {
            // ignored
        }
        Assert.Equal(Table.MaxColumns, Table.Columns);
        Assert.Equal(Table.MaxRows, Table.Rows);
    }
}