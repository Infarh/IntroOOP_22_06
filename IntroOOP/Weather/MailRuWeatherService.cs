using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroOOP.Weather;

public class MailRuWeatherService : WeatherServiceCSS
{
    private static readonly Dictionary<string, string> __Places = new(StringComparer.OrdinalIgnoreCase)
    {
        { "moscow", "moskva" },
        { "Москва", "moskva" },
        { "moskva", "moskva" },
    };

    public MailRuWeatherService(HttpClient Client) : base(Client, ".information__content__temperature")
    {
    }

    private const string __UrlTemplate = "https://pogoda.mail.ru/prognoz/{place}/";

    protected override string? GetRequestUrl(string Place)
    {
        if (!__Places.TryGetValue(Place, out var place_value))
            return null;

        return __UrlTemplate.Replace("{place}", place_value);
    }

    protected override string ClearString(string DataString)
    {
        return DataString.Trim('\t', '°', '\n');
    }
}