using IntroOOP;
using IntroOOP.Students;

const string names_file_name = @"Data\Names.txt";
var data_file = new FileInfo(names_file_name);

var last_names = new List<string>();
var first_names = new List<string>();
var patronymics = new List<string>();

//foreach (var values in NamesService.EnumPersonNames(data_file))
foreach (var values in data_file.EnumPersonNames())
{
    last_names.Add(values.LastName);
    first_names.Add(values.FirstName);
    patronymics.Add(values.Patronymic);
}


var students = new Student[1000];
var rnd = new Random();
for (var i = 0; i < students.Length; i++)
{
    students[i] = new Student
    {
        Id = i + 1,
        LastName = last_names[rnd.Next(last_names.Count)],
        Name = first_names[rnd.Next(first_names.Count)],
        Patronymic = patronymics[rnd.Next(patronymics.Count)],
    };
}



Console.WriteLine("Конец...");
Console.ReadLine();
