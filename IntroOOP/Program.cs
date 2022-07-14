using IntroOOP.Weather;

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

//var t1 = yandex.GetTemperature();
var t2 = mail.GetTemperature();

Console.WriteLine("Конец...");
Console.ReadLine();

