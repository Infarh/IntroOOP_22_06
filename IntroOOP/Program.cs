using IntroOOP;
using IntroOOP.Transport;

var car1 = new Car("Lada", new Vector2D(5, 7), new Vector2D(3, 5));
var car2 = car1;

ChangeCarLocationTo0(car1);

var car1_hash = car1.GetHashCode();
var car2_hash = car2.GetHashCode();

var is_equals = car1.Equals(car2);
var is_eq = car1 == car2;
var is_ref_equals = !object.ReferenceEquals(car1, car2);

car1.Location = new(0, 0);

var v1 = new Vector2D(5, 7);
var v2 = v1;

ChangeVectorValueTo0(ref v1);

v1.X = 555;




Console.WriteLine("Программа завершена.");
Console.ReadLine();

static void ChangeCarLocationTo0(Car car)
{
    car.Location = new Vector2D(0, 0);
    car.Acceleration = new();
    car.Speed = default;
}

static void ChangeVectorValueTo0(ref Vector2D vector)
{
    vector.X = 0;
    vector.Y = 0;
}