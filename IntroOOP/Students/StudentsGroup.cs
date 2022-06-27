using IntroOOP.Students.Base;

namespace IntroOOP.Students;

public class StudentsGroup : NamedItem
{
    public List<Student123> Students { get; set; } = new();
}
