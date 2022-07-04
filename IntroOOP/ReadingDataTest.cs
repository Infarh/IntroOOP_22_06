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

            var date = DateTime.Parse(values[0].Trim('"'));
            var temperature = double.Parse(values[1].Trim('"'), CultureInfo.InvariantCulture);
            var pressure = double.Parse(values[2].Trim('"'), CultureInfo.InvariantCulture);

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