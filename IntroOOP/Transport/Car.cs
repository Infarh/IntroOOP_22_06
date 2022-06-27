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

    //private string _Model;

    //public string Model
    //{
    //    get => _Model;
    //    set => _Model = value;
    //}

    public string Model { get; set; }


}
