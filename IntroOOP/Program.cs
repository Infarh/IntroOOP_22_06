using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

using IntroOOP;
using IntroOOP.Infrastructure;
using IntroOOP.Students;

const string names_file_name = @"Data\Names.txt";
var data_file = new FileInfo(names_file_name);

var (last_names, first_names, patronymics) = data_file.GetNames();



var students = Student.CreateRandomStudents(last_names, first_names, patronymics);

var serializer_xml = new XmlDataSerializer<Student[]>();
var serializer_bin = new BinaryDataSerializer<Student[]>();
var serializer_json = new JsonDataSerializer<Student[]>();
var serializer_json_ident = new JsonDataSerializer<Student[]> { WriteIdent = true };

const string students_data_file = "students.json";
Student.SaveToFile(students, students_data_file, serializer_json);

var result_students = Student.LoadFromFile(students_data_file, serializer_json);

Console.WriteLine("Конец...");
//Console.ReadLine();
