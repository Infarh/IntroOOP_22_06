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
serializer_json.WriteIdent = true;


using (var xml_file = File.Create("students.xml"))
    serializer_xml.Serialize(students, xml_file);

using (var bin_file = File.Create("students.bin"))
    serializer_bin.Serialize(students, bin_file);

using (var json_file = File.Create("students.json"))
    serializer_json.Serialize(students, json_file);

Console.WriteLine("Конец...");
Console.ReadLine();
