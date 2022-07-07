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

    public static (string[] LastNames, string[] FirstNames, string[] Patronymics) GetNames(this FileInfo file)
    {
        var last_names = new List<string>();
        var first_names = new List<string>();
        var patronymics = new List<string>();

        foreach (var values in file.EnumPersonNames())
        {
            last_names.Add(values.LastName);
            first_names.Add(values.FirstName);
            patronymics.Add(values.Patronymic);
        }

        return (last_names.ToArray(), first_names.ToArray(), patronymics.ToArray());
    }
}
