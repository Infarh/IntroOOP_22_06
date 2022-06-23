namespace IntroOOP;

public class StudentsGroup
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Student> Students { get; set; } = new();
}
