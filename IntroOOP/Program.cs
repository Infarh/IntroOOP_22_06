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

var v1 = new Vector2D(5, 0);

var v2 = new Vector2D(0, 7);

var v1_1 = v1 / 5;
var v2_1 = v2 / v2.Length;

var v3 = v1_1 + v2_1;

const double to_deg = 180 / Math.PI;
const double to_rad = Math.PI / 180;

var v1_v2_angle = (v1 ^ v2) * to_deg;
var v1_v3_angle = (v1 ^ v3) * to_deg;

Console.WriteLine("Конец...");
Console.ReadLine();
