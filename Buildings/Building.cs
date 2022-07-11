namespace Buildings;


public class Building
{
    private readonly int _Id;

    private readonly int _FloorsCount;

    private readonly int _FlatsPerFloorCount;

    private readonly double _FloorHeight;

    private readonly int _EntrancesCount;

    public int Id => _Id;

    public int FloorsCount => _FloorsCount;

    public int FlatsPerFloorCount => _FlatsPerFloorCount;

    public double FloorHeight => _FloorHeight;

    public int EntrancesCount => _EntrancesCount;

    public Building(int Id, int FloorsCount, int FlatsPerFloorCount, double FloorHeight, int EntrancesCount)
    {
        _Id = Id;
        _FloorsCount = FloorsCount;
        _FlatsPerFloorCount = FlatsPerFloorCount;
        _FloorHeight = FloorHeight;
        _EntrancesCount = EntrancesCount;
    }
}
