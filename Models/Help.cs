namespace MSNumbers.Models;

public class Help
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string Message => "Ця програма була написана мною. Якщо у вас виникли запитання, це ваші проблеми. C'est la vie.";
}