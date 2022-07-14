namespace IntroOOP.Weather;

public abstract class WeatherService : ISynoptic
{
    public abstract double GetTemperature(string Place);
}

public interface ISynoptic
{
    double GetTemperature(string Place);
}