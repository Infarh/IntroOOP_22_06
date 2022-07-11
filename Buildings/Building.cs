using System.Diagnostics;

namespace Buildings;

[DebuggerDisplay("Здание id:{Id}")]
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

    public override int GetHashCode()
    {
        //return HashCode.Combine(EntrancesCount, _FloorsCount, _FlatsPerFloorCount, _FloorHeight);

        var hash = 397; // простое число 0x18D (имеет "случайное" расположение битов 0b110001101)

        unchecked
        {
            hash = (hash * 0x18d) ^ EntrancesCount.GetHashCode();
            hash = (hash * 0x18d) ^ _FloorsCount.GetHashCode();
            hash = (hash * 0x18d) ^ _FlatsPerFloorCount.GetHashCode();
            hash = (hash * 0x18d) ^ _FloorHeight.GetHashCode();
        }

        return hash;
    }

    public override string ToString() => $"Здание (id:{Id}) подъездов: {EntrancesCount} "
        + $"этажей: {_FloorsCount} квартир на этаж: {_FlatsPerFloorCount} высота этажа: {_FloorHeight}";

    public static bool operator ==(Building b1, Building b2) => Equals(b1, b2);

    public static bool operator !=(Building b1, Building b2) => !(b1 == b2);
}