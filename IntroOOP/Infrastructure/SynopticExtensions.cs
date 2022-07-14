using IntroOOP.Weather;

namespace IntroOOP.Infrastructure;

public static class SynopticExtensions
{
    public static void Watch(this ISynoptic Synoptic, string Place, int Timeout)
    {
        while (true)
        {
            var t = Synoptic.GetTemperature(Place);
            Console.WriteLine("{0:HH:mm:ss.ff} - {1:f2}", DateTime.Now, t);

            Thread.Sleep(Timeout);
        }
    }
}