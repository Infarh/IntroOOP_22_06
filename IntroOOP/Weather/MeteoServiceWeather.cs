using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroOOP.Weather;

public class MeteoServiceWeather : WeatherServiceCSS
{
    public MeteoServiceWeather(HttpClient Client) : base(Client, "div.temperature span.value") { }

    protected override string GetRequestUrl() => "https://www.meteoservice.ru/weather/overview/moskva";

    protected override string ClearString(string DataString) => DataString.TrimEnd('°');
}
