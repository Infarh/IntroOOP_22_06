using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroOOP.Weather;

public class MeteoServiceWeather : WeatherServiceCSS
{
    private static readonly Dictionary<string, string> __Places = new(StringComparer.OrdinalIgnoreCase)
    {
        { "moscow", "moskva" },
        { "Москва", "moskva" },
        { "moskva", "moskva" },
    };

    public MeteoServiceWeather(HttpClient Client) : base(Client, "div.temperature span.value") { }


    private const string __UrlTemplate = "https://www.meteoservice.ru/weather/overview/{place}";

    protected override string? GetRequestUrl(string Place)
    {
        if (!__Places.TryGetValue(Place, out var place_value))
            return null;

        return __UrlTemplate.Replace("{place}", place_value);
    }

    protected override string ClearString(string DataString) => DataString.TrimEnd('°');
}
