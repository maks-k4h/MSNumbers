namespace MSNumbers.Views;

using Models;
public partial class TablePage : ContentPage
{
    private const int RowHeight                         = 50;
    private const int ColumnWidth                       = 120;
    private const int CellFontSize                      = 18;
    private static readonly Color LeadingCellColor      = Colors.LightGray;
    private static readonly Color CellColor             = Colors.White;

    // Available data cells
    private int _rows                                   = 0;
    private int _columns                                = 0;
    
    private Grid _grid;
    private Entry _formulaEntry;
    private Label _statusLabel;

    private int _debuggingConstatant;
    
    public TablePage()
    {
        InitializeComponent();

        _formulaEntry = new Entry
        {
            HorizontalOptions       = LayoutOptions.Center,
            WidthRequest            = 300,
            Margin                  = 10,
            FontSize                = 18,
        };

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

        _statusLabel = new Label()
        {
            Padding                 = new Thickness(20, 0),
            FontSize                = 18,
            TextColor               = Colors.White,
            HorizontalTextAlignment = TextAlignment.End,
            VerticalTextAlignment   = TextAlignment.Center
        };
        ShowSuccessStatus();

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
            _formulaEntry
        },0, 0);
        contentGrid.Add(new ScrollView{Content = _grid}, 0, 1);
        contentGrid.Add(_statusLabel, 0, 2);

        Content = contentGrid;

        LoadGrid();
    }

    private void LoadGrid()
    {
        Title = Table.Name.Length > 0 ? Table.Name : "Нова таблиця";
        
        for (var r = 0; r < Table.Rows; ++r)
        {
            AddRow();
        }

        for (var c = 0; c < Table.Columns; ++c)
        {
            AddColumn();
        }
    }
    
    private void GetHelpClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HelpPage));
    }

    private void AddRow()
    {
        try {
            _grid.RowDefinitions.Add(new RowDefinition(RowHeight));
            
            // Adding leading cell
            _grid.Add(new Label
            {
                BackgroundColor = LeadingCellColor,
                Text = $"{_rows + 1}",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = CellFontSize
            }, 0, _rows + 1);

            // Adding remaining cells
            for (int c = 0; c < _columns; ++c)
            {
                _grid.Add(new Button
                {
                    Background = CellColor,
                    Text = Table.NumbersToCellName(_rows, c),
                    TextColor = Colors.Black,
                    BorderWidth = 2,
                    BorderColor = Colors.LightGray,
                    CornerRadius = 0,
                    FontSize = CellFontSize
                }, c + 1, _rows + 1);
            }
            
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
            _grid.Add(new Label
            {
                BackgroundColor = LeadingCellColor,
                Text = $"{(char)('A' + _columns)}",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = CellFontSize
            }, _columns + 1, 0);
            
            // Adding remaining cells
            for (int r = 0; r < _rows; ++r)
            {
                _grid.Add(new Button
                {
                    Background = CellColor,
                    Text = Table.NumbersToCellName(r, _columns),
                    TextColor = Colors.Black,
                    BorderWidth = 2,
                    BorderColor = Colors.LightGray,
                    CornerRadius = 0,
                    FontSize = CellFontSize
                }, _columns + 1, r + 1);
            }
            
            ++_columns;
        }
        catch (Exception e)
        {
            throw new Exception("Exception while adding a column.");
        }
    }

    private void ShowSuccessStatus(string message = "Усе впорядку", string statusSymbol = "😎")
    {
        _statusLabel.Text = $"{message} {statusSymbol}";
        _statusLabel.BackgroundColor = Colors.Gray;
    }
    
    private void ShowFailureStatus(string message = "Щось пішло не так", string statusSymbol = "🤔")
    {
        _statusLabel.Text = $"{message} {statusSymbol}";
        _statusLabel.BackgroundColor = Colors.Red;
    }
}