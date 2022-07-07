using IntroOOP.Students.Base;

namespace IntroOOP.Students;

public class Student : NamedItem
{
    public string LastName { get; set; }

    public string Patronymic { get; set; }
}