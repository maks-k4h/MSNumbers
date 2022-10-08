using MSNumbers.Utils;

namespace MSNumbers.Views;

public partial class MainPage : ContentPage
{
    private Entry _filePathEntry;
    private Label _messageLabel;

    public MainPage()
    {
        InitializeComponent();

        var grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(400) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
            },
            RowDefinitions =
            {
                new RowDefinition()
            }
        };

        var createButton = new Button
        {
            Text = "Створити",
            FontSize = 22,
            HeightRequest = 80,
            Margin = 0,
        };

        var openButton = new Button
        {
            Text = "Відкрити",
            FontSize = 22,
            HeightRequest = 80,
            Margin = 0,
        };

        _filePathEntry = new Entry
        {
            Placeholder = "Шлях до файлу",
            BackgroundColor = Colors.White,
            FontSize = 20,
            HeightRequest = 60
        };

        var verticalStack = new VerticalStackLayout()
        {
            BackgroundColor = Colors.LightGray,
            Spacing = 10,
            Padding = 10
        };

        _messageLabel = new Label
        {
            FontSize = 18,
            TextColor = Colors.Red,
            HorizontalTextAlignment = TextAlignment.Center,
            Text = ""
        };

        verticalStack.Add(createButton);
        verticalStack.Add(openButton);
        verticalStack.Add(_filePathEntry);
        
        verticalStack.Add(_messageLabel);

        createButton.Clicked += _createButtonClicked;
        openButton.Clicked += _openButtonClicked;

        grid.Add(verticalStack, 0, 0);
        Content = grid;
    }

    private async void _createButtonClicked(object sender, EventArgs args)
    {
        try
        {
            Models.Table.CreateBlank();
            await Shell.Current.GoToAsync(nameof(TablePage));
        }
        catch (Exception e)
        {
            _showMessage($"{e.Message}");
        }
    }
    
    private void _openButtonClicked(object sender, EventArgs args)
    {
         _openFromFile((string)_filePathEntry.Text);
    }

    private void _showMessage(string message)
    {
        _messageLabel.Text = message;
    }

    private void _openFromFile(string path)
    {
        try
        {
            Utils.Deserializer.Deserialize(path);
            Shell.Current.GoToAsync(nameof(TablePage));
        }
        catch (FileNotFoundException)
        {
            _showMessage($"Шлях до таблиці невірний!");
        }
        catch (WrongFileFormatException)
        {
            _showMessage($"Формат файлу не підтримується!");
        }
        catch (Exception)
        {
            _showMessage($"Невідома помилка!");
        }
    }

    private void getHelpClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HelpPage));
    }
}