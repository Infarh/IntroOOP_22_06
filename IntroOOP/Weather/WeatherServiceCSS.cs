using AngleSharp.Html.Parser;

namespace IntroOOP.Weather;

public abstract class WeatherServiceCSS : WeatherService
{
    private readonly HttpClient _Client;

    private readonly string _SelectorCSS;

    protected WeatherServiceCSS(HttpClient Client, string SelectorCSS)
    {
        _Client = Client;
        _SelectorCSS = SelectorCSS;
    }

    protected abstract string? GetRequestUrl(string Place);

    protected virtual string ClearString(string DataString)
    {
        return DataString;
    }

    public override double GetTemperature(string Place)
    {
        var url = GetRequestUrl(Place);
        if (url is null)
            throw new InvalidOperationException($"Неизвестное место {Place}");

        var response = _Client.GetAsync(url).Result;
        var html_str = response.Content.ReadAsStringAsync().Result;

        var parser = new HtmlParser();
        var doc = parser.ParseDocument(html_str);

        var temp_node = doc.QuerySelector(_SelectorCSS);
        if (temp_node is null)
            throw new InvalidOperationException($"В полученной от сервера строке html элемент с селектором {_SelectorCSS} не найден");

        var temp_str = temp_node.TextContent;

        var temp_str_clear = ClearString(temp_str);

        if (!double.TryParse(temp_str_clear, out var temp_value))
            return double.NaN;

        return temp_value;
    }
}
