using MSNumbers.Models;
using MSNumbers.Utils.Packing;

namespace MSNumbers.Views;

public partial class MainPage : ContentPage
{
    private readonly Entry _filePathEntry;
    private readonly Label _messageLabel;

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
            Text            = "Створити",
            FontSize        = 22,
            HeightRequest   = 80,
            Margin          = 0,
        };

        var openButton = new Button
        {
            Text            = "Відкрити",
            FontSize        = 22,
            HeightRequest   = 80,
            Margin          = 0,
        };

        _filePathEntry = new Entry
        {
            Placeholder     = "Шлях до файлу",
            BackgroundColor = Colors.White,
            FontSize        = 20,
            HeightRequest   = 60
        };

        var verticalStack = new VerticalStackLayout()
        {
            BackgroundColor = Colors.LightGray,
            Spacing         = 10,
            Padding         = 10
        };

        _messageLabel = new Label
        {
            FontSize                = 18,
            TextColor               = Colors.Red,
            HorizontalTextAlignment = TextAlignment.Center,
            Text                    = ""
        };

        verticalStack.Add(createButton);
        verticalStack.Add(openButton);
        verticalStack.Add(_filePathEntry);
        
        verticalStack.Add(_messageLabel);

        createButton.Clicked += CreateButtonClicked;
        openButton.Clicked += OpenButtonClicked;
        
        grid.Add(verticalStack, 0);
        grid.Add(new Image
        {
            Source = "main_texture.jpg", 
            Aspect = Aspect.AspectFill
        },1);

        Content = grid;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ShowMessage("");
    }

    private async void CreateButtonClicked(object sender, EventArgs args)
    {
        try
        {
            Table.CreateBlank();
            await Shell.Current.GoToAsync(nameof(TablePage));
        }
        catch (Exception e)
        {
            ShowMessage($"{e.Message}");
        }
    }
    
    private async void OpenButtonClicked(object sender, EventArgs args)
    {
        OpenFromFile(_filePathEntry.Text);
    }

    private void ShowMessage(string message)
    {
        _messageLabel.Text = message;
    }

    private async void OpenFromFile(string path)
    {
        try
        {
            Deserializer.FromFile(path);
            await Shell.Current.GoToAsync(nameof(TablePage));
        }
        catch (FileNotFoundException)
        {
            ShowMessage("Шлях до таблиці невірний!");
        }
        catch (Exception e)
        {
            ShowMessage($"Файл пошкодженно!");
        }
    }

    private void GetHelpClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HelpPage));
    }
}