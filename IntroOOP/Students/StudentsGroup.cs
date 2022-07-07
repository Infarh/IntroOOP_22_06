using IntroOOP.Students.Base;

namespace IntroOOP.Students;

public class StudentsGroup : NamedItem
{
    public List<Student> Students { get; set; } = new();
}
