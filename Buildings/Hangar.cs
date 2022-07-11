namespace Buildings;

public class Hangar : Structure
{
    public double Square { get; }

    public Hangar(int Id, int EntrancesCount, double Square) : base(Id, EntrancesCount)
    {
        this.Square = Square;
    }
}
