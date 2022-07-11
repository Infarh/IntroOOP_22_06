
using Buildings;

//var building1 = new Building(1, 10, 15, 2.5, 3);
var building1 = BuildingConstructor.Build(10, 15, 2.5, 3);

var builder = new BuildingConstructor(17, 4, 2.7);

var building2 = builder.Build(15);
var building3 = builder.Build(3);

var is_buildings_equals = building1 == building2;
var is_buildings_equals1 = Equals(building1, building2);
var is_buildings_equals2 = building1.Equals(building2);
var is_buildings_equals_ref = ReferenceEquals(building1, building2);

var is_building_equals_to_string = building1.Equals("EntrancesCount=3;FloorHeight=2,5;FloorsCount=10;FlatsPerFloorCount=15");

Console.WriteLine("Конец...");
Console.ReadLine(); 
