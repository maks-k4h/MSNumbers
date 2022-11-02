namespace MSNumbers.Models;

public class Help
{
    public string Title                     => "Name";
    public string Version                   => "VersionString";
    public string Description               => "Довідка користувача знаходиться нижче. " +
                                                "При виникненні запитань зверніться до постачальника ПЗ.";

    public int DocumentationTitleFontSize   => 26;
    public int DocumentationFontSize        => 19;
}