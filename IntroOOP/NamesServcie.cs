using IntroOOP.Infrastructure;

namespace IntroOOP;

public static class NamesService
{
    public static IEnumerable<(string LastName, string FirstName, string Patronymic)> EnumPersonNames(this FileInfo file)
    {
        foreach (var line in file.EnumLines())
        {
            if(line.Length == 0) continue;


            var values = line.Split(' ');

            yield return (values[0], values[1], values[2]);
        }
    }
}
