namespace IntroOOP.Weather;

public class YandexWeather : WeatherServiceCSS
{
    public YandexWeather(HttpClient Client) : base(Client, "div.temp span.temp__value_with-unit") { }

    protected override string GetRequestUrl() => "https://yandex.ru/pogoda/moscow";
}
