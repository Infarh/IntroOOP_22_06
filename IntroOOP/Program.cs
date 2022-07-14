
using AngleSharp.Html.Parser;

var client = new HttpClient();

var response = client.GetAsync("https://yandex.ru/pogoda/moscow").Result;
var html = response
   .EnsureSuccessStatusCode()
   .Content
   .ReadAsStringAsync()
   .Result;

var parser = new HtmlParser();
var doc = parser.ParseDocument(html);

var temp_node = doc.QuerySelector("div.temp span.temp__value_with-unit");
var temp_str = temp_node.InnerHtml;

var temp = double.Parse(temp_str);

Console.WriteLine("Конец...");
Console.ReadLine();

