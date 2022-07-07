using IntroOOP.Infrastructure;
using IntroOOP.Students.Base;

namespace IntroOOP.Students;

[Serializable]
public class Student : NamedItem
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
}