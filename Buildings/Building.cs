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

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj is string)
        {
            var str = (string)obj;
            if (!str.Contains($"EntrancesCount={EntrancesCount}")) return false;
            if (!str.Contains($"FloorsCount={_FloorsCount}")) return false;
            if (!str.Contains($"FlatsPerFloorCount={_FlatsPerFloorCount}")) return false;
            if (!str.Contains($"FloorHeight={_FloorHeight}")) return false;
            return true;
        }

        if (obj.GetType() != typeof(Building)) return false;

        var other = (Building)obj;

        return EntrancesCount == other.EntrancesCount
            && _FloorsCount == other._FloorsCount
            && _FlatsPerFloorCount == other._FlatsPerFloorCount
            && _FloorHeight == other._FloorHeight;
    }
}