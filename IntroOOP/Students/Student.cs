using IntroOOP.Students.Base;

namespace IntroOOP.Students;

public class Student : NamedItem
{
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
            };
        }

        return students;
    }

    public string LastName { get; set; }

    public string Patronymic { get; set; }
}