using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using IntroOOP;
using IntroOOP.Students;

const string names_file_name = @"Data\Names.txt";
var data_file = new FileInfo(names_file_name);

var (last_names, first_names, patronymics) = data_file.GetNames();

var students = Student.CreateRandomStudents(last_names, first_names, patronymics);

//var serializer_xml = new XmlSerializer(typeof(Student[]));
//var serializer_bin = new BinaryFormatter();
//var serializer_json = new JsonSerializer(); // используется иначе
//JsonSerializer.

Console.WriteLine("Конец...");
Console.ReadLine();
