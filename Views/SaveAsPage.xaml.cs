using MSNumbers.Models;
using MSNumbers.Utils;

namespace MSNumbers.Views;

public partial class SaveAsPage : ContentPage
{
    private Entry _filePathEntry;
    private Label _messagLabel;
    
    public SaveAsPage()
    {
        InitializeComponent();
        
        _filePathEntry = new Entry
        {
            Placeholder = "Введіть шлях",
            FontSize = 18,
            WidthRequest = 300
        };

        var button = new Button
        {
            Text = "Зберегти",
            FontSize = 18,
        };
        button.Clicked += (sender, args) => Save(_filePathEntry.Text ?? "");

        _messagLabel = new Label
        {
            FontSize = 16,
            TextColor = Colors.Red,
            Text = " ",
            Padding = new Thickness(10, 5)
        };

        Content = new VerticalStackLayout
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new HorizontalStackLayout
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        _filePathEntry,
                        button
                    }
                },
                _messagLabel
            }
        };
    }

    private async Task Save(string path)
    {
        if (path.Length == 0)
        {
            ShowMessage("Необхідно вказати шлях!");
        }
        else
        {
            Table.SetPath(path);
            Table.Save();
            await Shell.Current.GoToAsync("..");
        }
    }

    private void ShowMessage(string message)
    {
        _messagLabel.Text = message;
    }
}