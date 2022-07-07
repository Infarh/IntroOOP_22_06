using IntroOOP;
using IntroOOP.Students;

const string names_file_name = @"Data\Names.txt";
var data_file = new FileInfo(names_file_name);

var (last_names, first_names, patronymics) = data_file.GetNames();

var students = Student.CreateRandomStudents(last_names, first_names, patronymics);



Console.WriteLine("Конец...");
Console.ReadLine();
