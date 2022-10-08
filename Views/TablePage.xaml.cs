namespace MSNumbers.Views;

public partial class TablePage : ContentPage
{
    public string Name = "Нова таблиця";
    public TablePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        Title = Name.Length > 0 ? Name : "Нова таблиця";
    }
    
    private void getHelpClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HelpPage));
    }
}