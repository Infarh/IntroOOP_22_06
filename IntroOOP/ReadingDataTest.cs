using System.Globalization;
using IntroOOP.Infrastructure;

namespace IntroOOP;

public static class ReadingDataTest
{
    public static void Run()
    {
        const string data_file_path = @"Data\WeatherMoscow.csv";

        var data_file = new FileInfo(data_file_path);

        var data = new List<WeatherInfo>();

        var lines_count = 0;
        //foreach (var line in FileInfoEx.EnumLines(data_file))
        foreach (var line in data_file.EnumLines())
        {
            lines_count++;
            if(lines_count < 8) continue;


            var values = line.Split(';');

            //var date = DateTime.Parse(values[0].Trim('"'));
            if (!DateTime.TryParse(values[0].Trim('"'), out var date))
                continue;

            //var temperature = double.Parse(values[1].Trim('"'), CultureInfo.InvariantCulture);
            if(!double.TryParse(values[1].Trim('"'), NumberStyles.Any, CultureInfo.InvariantCulture, out var temperature))
                continue;

            //var pressure = double.Parse(values[2].Trim('"'), CultureInfo.InvariantCulture);
            if (!double.TryParse(values[2].Trim('"'), NumberStyles.Any, CultureInfo.InvariantCulture, out var pressure))
                continue;

            //var info = new WeatherInfo();
            //info.Time = date;
            //info.Temperature = temperature;
            //info.Pressure = pressure;

            var info = new WeatherInfo
            {
                Time = date,
                Temperature = temperature,
                Pressure = pressure,
            };

            data.Add(info);
        }

    }
}