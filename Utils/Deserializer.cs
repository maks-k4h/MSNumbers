namespace MSNumbers.Utils;

public static class Deserializer
{
    public static void Deserialize(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException();
        if (!path.EndsWith(".msxl"))
            throw new WrongFileFormatException();
    }
}