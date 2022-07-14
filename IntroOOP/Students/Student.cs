using System.Diagnostics;
using IntroOOP.Infrastructure;
using IntroOOP.Students.Base;
using IntroOOP.Weather;
using Utilities.Logging;

namespace IntroOOP.Students;

[Serializable]
[DebuggerDisplay("Студент ({Id}) {LastName} {Name} {Patronymic} {Rating}")]
public class Student : NamedItem, ISynoptic, ILogger
{
    public static void SaveToFile(Student[] students, string FileName, StudentsSerializer serializer)
    {
        using var file = File.Create(FileName);
        serializer.Serialize(students, file);
    }

    public static Student[] LoadFromFile(string FileName, StudentsSerializer serializer)
    {
        using var file = File.OpenRead(FileName);
        return serializer.Deserialize(file);
    }

    public static Student[] CreateRandomStudents(string[] LastNames, string[] FirstNames, string[] Patronymics, int Count = 1000)
    {
        var students = new Student[Count];
        var rnd = new Random(Environment.TickCount);
        for (var i = 0; i < Count; i++)
        {
            students[i] = new Student
            {
                Id = i + 1,
                LastName = LastNames[rnd.Next(LastNames.Length)],
                Name = FirstNames[rnd.Next(FirstNames.Length)],
                Patronymic = Patronymics[rnd.Next(Patronymics.Length)],
                Rating = rnd.NextDouble() * 100,
            };
        }

        return students;
    }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public double Rating { get; set; }

    public override string ToString() => $"[id:{Id}] {LastName} {Name} {Patronymic} : {Rating:f2}";

    public double GetTemperature(string Place)
    {
        switch (Place.ToLower())
        {
            case "москва":
            case "moskva":
            case "moscow":
                return (Random.Shared.NextDouble() - 0.5) * 10 + 27;

            case "питер":
                return (Random.Shared.NextDouble() - 0.5) * 10 + 23;

            case "сочи":
                return (Random.Shared.NextDouble() - 0.5) * 10 + 35;

            default:
                throw new ArgumentOutOfRangeException(nameof(Place), Place, "Не знаю такого места");
        }
    }

    public void Log(string Message)
    {
        Console.WriteLine($"Запись студента в журнал: {Message}");
    }
}