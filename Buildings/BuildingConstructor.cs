using Utilities.Logging;

namespace Buildings;

public class BuildingConstructor
{
    /* - Статическая часть класса ------------------------------------------------------------------------------ */

    public static Logger Logger { get; set; }

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
        Logger?.Log($"Построено здание {building}");
        return building;
    }

    /* - Не статическая часть класса --------------------------------------------------------------------------- */

    //public event EventHandler<EventArgs> BuildingCreated;
    public event Action<Building> BuildingCreated;

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
        Logger?.Log($"Построено здание {building} строителем {this}");

        BuildingCreated?.Invoke(building);

        return building;
    }
}
