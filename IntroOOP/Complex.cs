namespace IntroOOP;

public struct Complex
{
    public double Re { get; }
    public double Im { get; }

    public double Abs => Math.Sqrt(Re * Re + Im * Im);

    public double Arg => Math.Atan2(Im, Re);

    public Complex(double re, double im)
    {
        Re = re;
        Im = im;
    }

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Re + b.Re, a.Im + b.Im);
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Re - b.Re, a.Im - b.Im);
    }
}
