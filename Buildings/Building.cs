namespace Buildings;

public class Building : Structure
{
    private int _FloorsCount;

    private readonly int _FlatsPerFloorCount;

    private readonly double _FloorHeight;

    public int FloorsCount { get => _FloorsCount; set => _FloorsCount = value; }

    public int FlatsPerFloorCount { get { return _FlatsPerFloorCount; } }

    public double FloorHeight => _FloorHeight;

    public Building(int Id, int FloorsCount, int FlatsPerFloorCount, double FloorHeight, int EntrancesCount) : base(Id, EntrancesCount)
    {
        _FloorsCount = FloorsCount;
        _FlatsPerFloorCount = FlatsPerFloorCount;
        _FloorHeight = FloorHeight;
    }
}