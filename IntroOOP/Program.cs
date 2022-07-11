
using Buildings;

using Utilities.Logging;

var watcher = new FileSystemWatcher("Data", "*.txt");
watcher.Created += OnTextFileCreated;
//watcher.Created -= OnTextFileCreated;

watcher.EnableRaisingEvents = true;

var log = new List<string>();

//BuildingConstructor.Logger = new PrefixFileLogger("building.log") { Prefix = " )=>", AddTime = false };
BuildingConstructor.Logger = new ListLogger(log);

//var building1 = new Building(1, 10, 15, 2.5, 3);
var building1 = BuildingConstructor.Build(10, 15, 2.5, 3);

var builder = new BuildingConstructor(17, 4, 2.7);
builder.BuildingCreated += OnNewBuildingCreated;

var builder_bindings = new List<Building>();
//builder.BuildingCreated += OnNewBuildingCreatedAddToList;

//void OnNewBuildingCreatedAddToList(Building NewBuilding)
//{
//    builder_bindings.Add(NewBuilding);
//}
builder.BuildingCreated += NewBuilding => builder_bindings.Add(NewBuilding);

var building2 = builder.Build(15);
var building3 = builder.Build(3);

var is_buildings_equals = building1 == building2;
var is_buildings_equals1 = Equals(building1, building2);
var is_buildings_equals2 = building1.Equals(building2);
var is_buildings_equals_ref = ReferenceEquals(building1, building2);

var is_building_equals_to_string = building1.Equals("EntrancesCount=3;FloorHeight=2,5;FloorsCount=10;FlatsPerFloorCount=15");

Console.WriteLine("Конец...");
Console.ReadLine();

log.ForEach(Console.WriteLine);

static void OnTextFileCreated(object sender, FileSystemEventArgs e)
{
    Console.WriteLine("Создан файл {0}", e.Name);

    using var reader = File.OpenText(e.FullPath);
    while(!reader.EndOfStream)
        Console.WriteLine(reader.ReadLine());

    Console.WriteLine("---------------------------");
    Console.WriteLine();
}

static void OnNewBuildingCreated(Building building)
{
    Console.WriteLine("Создано здание: {0}", building);
}