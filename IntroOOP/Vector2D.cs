namespace IntroOOP;

public class Vector2D
{
    public double X { get; set; }

    public double Y { get; set; }

    public Vector2D() { }

    public Vector2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Vector2D Mul(double a)
    {
        return new Vector2D(X * a, Y * a);
    }

    public Vector2D Add(Vector2D v)
    {
        return new Vector2D(X + v.X, Y + v.Y);
    }

    public override string ToString()
    {
        return $"{{x{X:f3};y{Y:f2}}}";
    }
}
