namespace IntroOOP.Transport;

public class Car
{
    private static List<Car> __KnownCars = new List<Car>();

    public static int GetKnownCarsCount()
    {
        return __KnownCars.Count;
    }

    private Vector2D _Location = new Vector2D();

    public Vector2D Location { get => _Location; set => _Location = value; }

    public Vector2D Speed { get; set; } = new();

    public Vector2D Acceleration { get; set; } = new();

    public string Name { get; set; }

    public Car() // Конструктор по умолчанию
    {
        Name = "Машина!";
    }

    public Car(string name, Vector2D location, Vector2D speed)
    {
        Name = name;
        _Location = location;
        Speed = speed;
    }

    public void Move(double dt)
    {
        Speed = Speed.Add(Acceleration.Mul(dt));
        _Location = _Location.Add(Speed.Mul(dt).Add(Acceleration.Mul(dt * dt * 0.5)));

        //_Speed += Acceleration * dt;
        //_X += _Speed * dt + Acceleration * dt * dt * 0.5;
    }

    public void PrintPosition()
    {
        Console.WriteLine("{0} находится в точке {1:f3} м и имеет скорость {2:f2} м/с", Name, _Location, Speed);
    }
}
