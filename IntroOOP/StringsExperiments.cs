using System.Text;

namespace IntroOOP;

public static class StringsExperiments
{
    public static void Run()
    {
        var str = "Hello World!";

        char[] chars = str.ToCharArray();
        chars[4] = 'O';

        str = new string(chars);

        //for (var i = 0; i < 10_000; i++)
        //    result += str;

        var builder = new StringBuilder();
        for (var i = 0; i < 10_000; i++)
            builder.Append(str).Append(',');

        if (builder.Length > 0)
            builder.Length--;

        var result = builder.ToString();

        var values_str = "Last name = Invanov; First name = Ivan; Patronymic = Ivanovich; Age = 32";

        var person = GetPerson(values_str);

        var str_ptr = str.AsSpan(); // Span<T>
        var space_index = str_ptr.IndexOf(' ');
        var str1_ptr = str_ptr.Slice(0, space_index);
        var str2_ptr = str_ptr.Slice(space_index + 1);

        var str3_ptr = str_ptr[0..space_index];
        var str4_ptr = str_ptr[..space_index];
        var str5_ptr = str_ptr[space_index..];
    }

    private static Person GetPerson(string data)
    {
        var values = data.Split(';');

        var person = new Person();

        foreach (var value_str in values)
        {
            var vv = value_str.Split('=');

            var key = vv[0].Trim(' ');
            var value = vv[1].Trim(' ');

            switch (key)
            {
                case "Last name":
                    person.LastName = value;
                    break;

                case "First name":
                    person.FirstName = value;
                    break;

                case "Patronymic":
                    person.Patronymic = value;
                    break;

                case "Age":
                    person.Age = int.Parse(value);
                    break;
            }

        }


        return person;
    }
}

class Person
{
    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Patronymic { get; set; }

    public int Age { get; set; }
}
