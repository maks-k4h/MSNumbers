using MSNumbers.Models;
using MSNumbers.Models.Exceptions;
using MSNumbers.Utils.Packing;

namespace MSNumbersTests;

public class CellTest
{
    [Fact]
    public void CellInitialization()
    {
        var cell = new Cell();
        Assert.Empty(cell.StringValue);
        Assert.Empty(cell.GetFormula());
        Assert.Equal(0, cell.NumericalValue);
    }

    [Fact]
    public void DifferentiateTextAndNumericalFormulas()
    {
        var cell = new Cell();
        string s;
        
        s = "The Four Seasons.";
        cell.SetFormula(s);
        Assert.Equal(s.Trim(), cell.StringValue);
        Assert.Equal(0, cell.NumericalValue);
        
        s = "=3.3";
        cell.SetFormula(s);
        Assert.Equal(3.3, cell.NumericalValue);
    }

    [Fact]
    public void FileDeliminatorsInFormulas()
    {
        try
        {
            var cell = new Cell();
            cell.SetFormula($"some formula {Serializer.ColumnDelimiter}");
            Assert.Fail("Formula with serializer's column delimiter added.");
        }
        catch (Exception)
        {
            // Ignore
        }
        
        try
        {
            var cell = new Cell();
            cell.SetFormula($"some formula {Serializer.RowDelimiter}");
            Assert.Fail("Formula with serializer's row delimiter added.");
        }
        catch (Exception)
        {
            // Ignore
        }
        
        try
        {
            var cell = new Cell();
            cell.SetFormula($"={Serializer.ColumnDelimiter}");
            Assert.Fail("Formula with serializer's column delimiter added.");
        }
        catch (Exception)
        {
            // Ignore
        }
    }

    [Fact]
    public void IgnoreWhileSpaces()
    {
        string s;
        var cell = new Cell();
        
        s = "               Hi.";
        cell.SetFormula(s);
        Assert.Equal(s.Trim(), cell.StringValue);
        Assert.Equal(0, cell.NumericalValue);

        s = "   = (12 )   ";
        cell.SetFormula(s);
        Assert.Equal("12", cell.StringValue);
        Assert.Equal(12, cell.NumericalValue);
    }

    [Fact]
    public void SettingAndRemovingConnections()
    {
        Table.CreateBlank();
        
        Assert.Empty(Table.GetCell(0, 0)._children);
        Assert.Empty(Table.GetCell(0, 1)._children);

        Table.SetCellFormula(0,1,"=5");
        Table.SetCellFormula(0,0, "=b1 + 12");
        Assert.Equal(17, Table.GetCellNumericalResult(0, 0));
        Assert.Equal(5, Table.GetCellNumericalResult(0, 1));
        Assert.Empty(Table.GetCell(0, 0)._children);
        Assert.NotEmpty(Table.GetCell(0, 1)._children);
        Assert.Equal(Table.GetCell(0, 0), Table.GetCell(0, 1)._children[0]);
        
        Table.SetCellFormula(0,0, "=33");
        Assert.Equal(33, Table.GetCellNumericalResult(0, 0));
        Assert.Equal(5, Table.GetCellNumericalResult(0, 1));
        
        Table.SetCellFormula(0,1,"=inc(a1)");
        Assert.Equal(33, Table.GetCellNumericalResult(0, 0));
        Assert.Equal(34, Table.GetCellNumericalResult(0, 1));
        Assert.NotEmpty(Table.GetCell(0, 0)._children);
        Assert.Empty(Table.GetCell(0, 1)._children);
        Assert.Equal(Table.GetCell(0, 1), Table.GetCell(0, 0)._children[0]);
        
        Table.SetCellFormula(0,0, "Hello");
        Assert.Equal(0, Table.GetCellNumericalResult(0, 0));
        Assert.Equal(1, Table.GetCellNumericalResult(0, 1));
        
        // TODO: tests on cells with multiple dependencies should be added
    }

    [Fact]
    public void UpdatingChildren()
    {
        Table.CreateBlank();
        
        Table.SetCellFormula(0, 0, "=inc(b1)");
        Assert.Equal(1, Table.GetCellNumericalResult(0,0));
        Table.SetCellFormula(0,1, "=33");
        Assert.Equal(34, Table.GetCellNumericalResult(0,0));
        Assert.Equal("34", Table.GetCellStringResult(0, 0));
        Assert.Equal("33", Table.GetCellStringResult(0, 1));
        
        Table.SetCellFormula(0, 2, "=    1 + b1");
        Assert.Equal(34, Table.GetCellNumericalResult(0,2));
        
        Table.SetCellFormula(0, 1, "= 5");
        Assert.Equal(6, Table.GetCellNumericalResult(0,0));
        Assert.Equal(6, Table.GetCellNumericalResult(0,2));
        Assert.Equal(2, Table.GetCell(0,1)._children.Count);
        
        // TODO: tests on cells with multiple dependencies should be added
    }

    [Fact]
    public void PreventingRecursions()
    {
        Table.CreateBlank();
        
        // a1 -> b1 -> c1 -> b2
        // a1 -> b2 -> b1
        Table.SetCellFormula(0, 0, "= b1 - b2");
        Assert.Equal(1, Table.GetCell(0, 1)._children.Count);
        Assert.Equal(1, Table.GetCell(1, 1)._children.Count);
        Table.SetCellFormula(1, 1, "= dec(b1)");
        Assert.Equal(2, Table.GetCell(0, 1)._children.Count);
        Table.SetCellFormula(0, 1, "= c1");
        Assert.Equal(1, Table.GetCell(0,2)._children.Count);

        try
        {
            Table.SetCellFormula(0, 2, "=b2");
            Assert.Fail("Recursion has benn allowed.");
        }
        catch (Exception)
        {
            // ignore
        }
        
        // no new connections
        Assert.Equal(2, Table.GetCell(0, 1)._children.Count);
        Assert.Equal(1, Table.GetCell(1, 1)._children.Count);
        Assert.Equal(1, Table.GetCell(0,2)._children.Count);

    }
}