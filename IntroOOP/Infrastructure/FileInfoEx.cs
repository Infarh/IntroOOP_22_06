namespace IntroOOP.Infrastructure;

public static class FileInfoEx
{
    public static IEnumerable<string> EnumLines(this FileInfo file)
    {
        using var reader = file.OpenText();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            yield return line!;
        }
    }
}
