namespace IntroOOP.Transport;

public class Car
{
    private static List<Car> __KnownCars = new List<Car>();

    public static int GetKnownCarsCount()
    {
        return __KnownCars.Count;
    }

    private double _X;

    private double _Speed;

    public double GetX()
    {
        return _X;
    }

    public void SetX(double x)
    {
        _X = x;
    }

    public double ReadOnlyX => _X;

    public double X
    {
        get
        {
            return _X;
        }
        set
        {
            _X = value;
        }
    }

    public double GetSpeed()
    {
        return _Speed;
    }

    public void SetSpeed(double speed)
    {
        _Speed = speed;
    }

    public double Speed
    {
        get => _Speed;
        set => _Speed = value;
    }

    public double Acceleration { get; set; }

    //private string _Name;

    //public string Name
    //{
    //    get => _Name;
    //    set => _Name = value;
    //}

    //private string '<Name>k__BackingField';

    public string Name { get; set; }


    public Car() // Конструктор по умолчанию
    {
        Name = "Машина!";
        _X = 50;
        _Speed = 3;
    }

    public Car(string name, double x, double speed)
    {
        Name = name;
        _X = x;
        _Speed = speed;
    }

    public void Move(double dt)
    {
        _Speed += Acceleration * dt;
        _X += _Speed * dt + Acceleration * dt * dt * 0.5;
    }

    public void PrintPosition()
    {
        Console.WriteLine("{0} находится в точке {1:f3} м и имеет скорость {2:f2} м/с", Name, _X, _Speed);
    }
}
