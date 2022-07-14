using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroOOP.Weather;

public class MailRuWeatherService : WeatherServiceCSS
{
    public MailRuWeatherService(HttpClient Client) : base(Client, ".information__content__temperature")
    {
    }

    protected override string GetRequestUrl() => "https://pogoda.mail.ru/prognoz/moskva/";

    protected override string ClearString(string DataString)
    {
        return DataString.Trim('\t', '°', '\n');
    }
}