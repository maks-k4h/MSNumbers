using MSNumbers.Utils;

namespace MSNumbers.Views;

using Models;
public partial class TablePage : ContentPage
{
    private const int RowHeight                             = 50;
    private const int ColumnWidth                           = 180;
    private const int CellFontSize                          = 18;
    private static readonly Color LeadingCellColor          = Colors.LightGray;
    private static readonly Color CellColor                 = Colors.White;
    private static readonly Color CellBorderColor           = Colors.LightGray;
    private static readonly Color SelectedCellBorderColor   = Colors.Black;

    // Available data cells
    private int _rows                                   = 0;
    private int _columns                                = 0;

    private int _selectedRow                            = 0;
    private int _selectedCol                            = 0;
    private Button _selectedCell                        = null;
    
    private Grid _grid;
    private Entry _formulaEntry;
    private Label _statusLabel;
    
    public TablePage()
    {
        InitializeComponent();
        InitializeFormulaEntry();
        InitializeDataGrid();
        InitializeMessageLabel();
        
        var applyFormulaButton = new Button
        {
            Text                = "Застосувати",
            HeightRequest       = 40,
        };
        applyFormulaButton.Clicked += (sender, args) => { FormulaEdited(_formulaEntry.Text ?? ""); };
        
        var contentGrid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = 70 },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = 40 }
            }
        };
        contentGrid.Add(new HorizontalStackLayout
        {
            _formulaEntry,
            applyFormulaButton
        },0, 0);
        contentGrid.Add(new ScrollView{Content = _grid}, 0, 1);
        contentGrid.Add(_statusLabel, 0, 2);

        Content = contentGrid;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateTitle();
    }

    private void InitializeFormulaEntry()
    {
        _formulaEntry = new Entry
        {
            Placeholder         = "Введіть формулу",
            HorizontalOptions   = LayoutOptions.Center,
            HeightRequest       = 40,
            WidthRequest        = 300,
            Margin              = 10,
            FontSize            = 18,
        };
    }

    private void InitializeDataGrid()
    {
        _grid = new Grid
        {
            BackgroundColor =       Colors.White,
            ColumnSpacing           = 5,
            RowSpacing              = 5,
            RowDefinitions          =
            {
                new RowDefinition(RowHeight)
            },
            ColumnDefinitions =
            {
                new ColumnDefinition(ColumnWidth)
            }
        };
        _grid.Add(new Label{BackgroundColor = LeadingCellColor});
        
        for (var r = 0; r < Table.Rows; ++r)
        { AddRow(); }
        
        for (var c = 0; c < Table.Columns; ++c)
        { AddColumn(); }
    }

    private void InitializeMessageLabel()
    {
        _statusLabel = new Label()
        {
            Padding                 = new Thickness(20, 0),
            FontSize                = 18,
            TextColor               = Colors.White,
            HorizontalTextAlignment = TextAlignment.End,
            VerticalTextAlignment   = TextAlignment.Center
        };
        
        ShowDefaultStatus();
    }
    
    private void GetHelpClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HelpPage));
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        if (!Table.HasPath())
            Shell.Current.GoToAsync(nameof(Views.SaveAsPage));
        else
        {
            Table.Save();
            ShowSuccessStatus("Зміни збережено","💾");
        }
    }

    private void SaveAsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SaveAsPage));
    }

    private void AddRow()
    {
        try {
            _grid.RowDefinitions.Add(new RowDefinition(RowHeight));
            
            // Adding leading cell
            RenderCell(_rows + 1, 0);

            // Adding remaining cells
            for (int c = 0; c < _columns; ++c)
            { RenderCell(_rows + 1, c + 1); }
            
            ++_rows;
        }
        catch
        {
            throw new Exception($"Exception while adding a row.");
        }
    }

    private void AddColumn()
    {
        try {
            _grid.ColumnDefinitions.Add(new ColumnDefinition(ColumnWidth));
            
            // Adding leading cell
            RenderCell( 0, _columns + 1);
            
            // Adding remaining cells
            for (int r = 0; r < _rows; ++r)
            {
                RenderCell(r + 1, _columns + 1);
            }
            
            ++_columns;
        }
        catch (Exception)
        {
            throw new Exception("Exception while adding a column.");
        }
    }

    // render either leading or data cell
    // 0 row/col are leading, 1 row/col correspond to
    // first data row/col, i.e. have 0 row/col id
    // in the data table
    private void RenderCell(int row, int col)
    {
        if (row == 0 && col == 0)
        {
            _grid.Add(new Label
            {
                BackgroundColor = LeadingCellColor
            }, col, row);
        }
        else if (row == 0)
        {
            _grid.Add(new Label
            {
                BackgroundColor = LeadingCellColor,
                Text = $"{Table.NumberToAlphabeticSystem(col - 1)}",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = CellFontSize
            }, col, row);
        }
        else if (col == 0)
        {
            _grid.Add(new Label
            {
                BackgroundColor = LeadingCellColor,
                Text = $"{row}",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = CellFontSize
            }, col, row);
        }
        else
        {
            // creating frontend
            var button = new Button
            {
                Background = CellColor,
                TextColor = Colors.Black,
                BorderWidth = 2,
                BorderColor = CellBorderColor,
                CornerRadius = 0,
                FontSize = CellFontSize
            };
            
            // setting data binding
            button.BindingContext = Table.GetCell(row - 1, col - 1);
            button.SetBinding(Button.TextProperty, nameof(Cell.StringValue));
            
            // adding on-clicked action
            button.Clicked += (sender, args) =>
            {
                CellSelected((Button)sender, row - 1, col - 1);
            };
            
            // "rendering" the button
            _grid.Add(button, col, row);
        }
    }

    private void CellSelected(Button sender, int row, int col)
    {
        // changing properties of the previously active cell
        if (_selectedCell is not null)
            _selectedCell.BorderColor = CellBorderColor;
        
        // updating info about current cell
        _selectedCell = sender;
        _selectedRow = row;
        _selectedCol = col;
        
        // setting current cell color
        _selectedCell.BorderColor = SelectedCellBorderColor;

        SetFormulaEntryText(Table.GetCellFormula(row, col));
    }

    private void SetFormulaEntryText(string text)
    {
        _formulaEntry.Text = text;
    }

    private void FormulaEdited(string formula)
    {
        if (_selectedCell is null)
            return;
        try
        {
            Table.SetCellFormula(_selectedRow, _selectedCol, formula);
            ShowDefaultStatus();
        }
        catch (Exception e)
        {
            ShowFailureStatus(e.Message);
        }
        
    }

    private void ShowSuccessStatus(string message = "Чудово!", string statusSymbol = "🌈")
    {
        _statusLabel.Text = $"{message} {statusSymbol}";
        _statusLabel.BackgroundColor = Colors.Green;
    }
    
    private void ShowDefaultStatus(string message = "Усе впорядку", string statusSymbol = "😎")
    {
        _statusLabel.Text = $"{message} {statusSymbol}";
        _statusLabel.BackgroundColor = Colors.Gray;
    }

    private void ShowFailureStatus(string message = "Щось пішло не так", string statusSymbol = "🤔")
    {
        _statusLabel.Text = $"{message} {statusSymbol}";
        _statusLabel.BackgroundColor = Colors.Red;
    }

    private void UpdateTitle()
    {
        Title = Table.Name;
    }
}