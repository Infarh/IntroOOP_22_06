namespace IntroOOP;

public struct Vector2D
{
    public double X { get; set; }

    public double Y { get; set; }

    public double Length
    {
        get
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }

    public double Angle => Math.Atan2(Y, X);

    //public Vector2D() { }

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

    public static Vector2D operator +(Vector2D v1, Vector2D v2)
    {
        return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static Vector2D operator -(Vector2D v1, Vector2D v2)
    {
        return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
    }

    public static Vector2D operator +(Vector2D v1, double a)
    {
        return new Vector2D(v1.X + a, v1.Y + a);
    }

    public static Vector2D operator +(double a, Vector2D v1)
    {
        return new Vector2D(v1.X + a, v1.Y + a);
    }

    public static Vector2D operator -(Vector2D v1, double a)
    {
        return new Vector2D(v1.X - a, v1.Y - a);
    }

    public static Vector2D operator -(double a, Vector2D v1)
    {
        return new Vector2D(a - v1.X, a - v1.Y);
    }

    public static Vector2D operator *(Vector2D v1, double a)
    {
        return new Vector2D(v1.X * a, v1.Y * a);
    }

    public static Vector2D operator *(double a, Vector2D v1)
    {
        return new Vector2D(v1.X * a, v1.Y * a);
    }

    public static Vector2D operator /(Vector2D v1, double a)
    {
        return new Vector2D(v1.X / a, v1.Y / a);
    }

    public static Vector2D operator /(double a, Vector2D v1)
    {
        return new Vector2D(a / v1.X, a / v1.Y);
    }

    public static double operator *(Vector2D v1, Vector2D v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y;
    }

    public static double operator ^(Vector2D v1, Vector2D v2)
    {
        var k = (v1 * v2) / (v1.Length * v2.Length);
        return Math.Acos(k);
    }

    public static implicit operator double(Vector2D v) => v.Length;

    public static explicit operator Vector2D(double v) => new(v / Math.Sqrt(2), v / Math.Sqrt(2));
}
