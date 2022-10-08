namespace MSNumbers;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(Views.TablePage), typeof(Views.TablePage));
        Routing.RegisterRoute(nameof(Views.SaveAsPage), typeof(Views.SaveAsPage));
        Routing.RegisterRoute(nameof(Views.HelpPage), typeof(Views.HelpPage));
    }
}