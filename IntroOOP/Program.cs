using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Buildings;
using IntroOOP.Infrastructure;
using IntroOOP.Students;
using IntroOOP.Weather;

using System.Linq;

var students = new List<Student>();

for (var i = 1; i <= 1000; i++)
{
    students.Add(new()
    {
        Id = i,
        LastName = $"Фамилия-{i}",
        Name = $"Имя-{i}",
        Patronymic = $"Отчество-{i}",
        Rating = Random.Shared.NextDouble() * 100,
    });
}

RemoveLastStudents(students);

var student_group = new StudentsGroup();
student_group.Students.AddRange(students);

RemoveLastStudents(student_group, 20);

var best_students = student_group
   .OrderByDescending(student => student.Rating)
   .Take(10)
   .ToArray();

var average_best_stud = best_students.Average(s => s.Rating);

var last_students = student_group
   .OrderBy(student => student.Rating)
   .Take(10)
   .ToArray();
var average_last_stud = last_students.Average(s => s.Rating);


var average_rating = student_group.Average(s => s.Rating);

//using AngleSharp.Html.Parser;

var rnd = new Random();
var today = DateTime.Today;
var user_agent = string.Format("Mozilla/5.0 (Windows NT 6.1; WOW64; rv:{0}.0) Gecko/{2}{3:00}{4:00} Firefox/{0}.0.{1}",
    rnd.Next(3, 14),
    rnd.Next(1, 10),
    rnd.Next(today.Year - 4, today.Year),
    rnd.Next(12),
    rnd.Next(30));

var client = new HttpClient
{
    DefaultRequestHeaders =
    {
        { "User-Agent", user_agent },
        //{ "accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"},
        //{ "accept-encoding", "gzip, deflate, br"}
    }
};

//client.DefaultRequestHeaders.Add("User-Agent", user_agent);
//text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9

//var response = client.GetAsync("https://yandex.ru/pogoda/moscow").Result;
//var html = response
//   .EnsureSuccessStatusCode()
//   .Content
//   .ReadAsStringAsync()
//   .Result;

//var parser = new HtmlParser();
//var doc = parser.ParseDocument(html);

//var temp_node = doc.QuerySelector("div.temp span.temp__value_with-unit");
//var temp_str = temp_node.InnerHtml;

//var temp = double.Parse(temp_str);


//var yandex = new YandexWeather(client);
var mail = new MailRuWeatherService(client);
var meteo_service = new MeteoServiceWeather(client);

var student = new Student
{
    Id = 1,
    LastName = "Иванов",
    Name = "Иван",
    Patronymic = "Иванович"
};

BuildingConstructor.Logger = student;
var constructor = new BuildingConstructor(5, 4, 2.7);

constructor.Build(5);
constructor.Build(7);
constructor.Build(3);

//student.Watch("Москва", 2500);
mail.Watch("Москва", 2500);

//WatchForWeather(student, "Москва", 2500);
//WatchForWeather(mail, "Москва", 2500);

//var t1 = yandex.GetTemperature("moscow);
var t2 = mail.GetTemperature("moscow");
var t3 = meteo_service.GetTemperature("МоСкВа");

Console.WriteLine("Конец...");
Console.ReadLine();


static void WatchForWeather(ISynoptic Synoptic, string Place, int Timeout)
{
    while (true)
    {
        var t = Synoptic.GetTemperature(Place);
        Console.WriteLine("{0:HH:mm:ss.ff} - {1:f2}", DateTime.Now, t);

        Thread.Sleep(Timeout);
    }
}

static void RemoveLastStudents(IList<Student> Students, int Count = 10)
{
    var last_students = Students.OrderByDescending(s => s.Rating).Take(Count).ToArray();
    foreach (var student in last_students)
        Students.Remove(student);
}
