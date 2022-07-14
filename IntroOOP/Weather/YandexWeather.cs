namespace IntroOOP.Weather;

public class YandexWeather : WeatherServiceCSS
{
    private static readonly Dictionary<string, string> __Places = new(StringComparer.OrdinalIgnoreCase)
    {
        { "moscow", "moscow" },
        { "Москва", "moscow" },
        { "moskva", "moscow" },
    };

    public YandexWeather(HttpClient Client) : base(Client, "div.temp span.temp__value_with-unit") { }

    private const string __UrlTemplate = "https://yandex.ru/pogoda/{place}";

    protected override string? GetRequestUrl(string Place)
    {
        if (!__Places.TryGetValue(Place, out var place_value))
            return null;
        
        return __UrlTemplate.Replace("{place}", place_value);
    }
}
