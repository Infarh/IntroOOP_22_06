namespace Buildings;

public class BuildingConstructor
{
    /* - Статическая часть класса ------------------------------------------------------------------------------ */

    private static int _FreeId = 0;

    private static int CreateId()
    {
        return ++_FreeId;
    }

    private static readonly Dictionary<int, Building> __AllBuildings = new();

    public static Building Build(int FloorsCount, int FlatsPerFloorCount, double FloorHeight, int EntrancesCount)
    {
        var id = CreateId();
        var building = new Building(id, FloorsCount, FlatsPerFloorCount, FloorHeight, EntrancesCount);

        __AllBuildings.Add(id, building);
        return building;
    }

    /* - Не статическая часть класса --------------------------------------------------------------------------- */

    private int _FloorsCount;

    private int _FlatsPerFloorCount;

    private double _FloorHeight;

    public BuildingConstructor(int FloorsCount, int FlatsPerFloorCount, double FloorHeight)
    {
        _FloorsCount = FloorsCount;
        _FlatsPerFloorCount = FlatsPerFloorCount;
        _FloorHeight = FloorHeight;
    }


    public Building Build(int EntrancesCount)
    {
        var id = CreateId();
        var building = new Building(id, _FloorsCount, _FlatsPerFloorCount, _FloorHeight, EntrancesCount);

        __AllBuildings.Add(id, building);
        return building;
    }
}
