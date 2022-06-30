using IntroOOP;
using IntroOOP.Transport;

var car1 = new Car("Lada", new Vector2D(5, 7), new Vector2D(3, 5));
var car2 = car1;
var car3 = new Car("Volvo", new(3, 2), new(4, 5));

var cars = new Car[] { car1, car2, car3 };

cars[1].Name = "Lada Kanalya";

ChangeCarLocationTo0(cars[1]);

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

InitializeRandomVector(out v1);
PrintVector(v1);

int x; // = Convert.ToInt32("123");
if (!int.TryParse("123", out x))
    x = -1;

double pi = 3.14159265358979;
//int y = Convert.ToInt32(pi);
int y = (int)pi;

var vectors = new Vector2D[] { v1, v2, v2, new(1,1) };
var vectors_list = new List<Vector2D>();
vectors_list.Add(v1);
vectors_list.Add(v2);
vectors_list.Add(v2);
vectors_list.Add(new(1,1));

vectors[1].X = 5000;
vectors[3].X = -5000;

//vectors_list[1].X = 5000;
//vectors_list[3].X = -5000;

var max_vector = GetVectorWithMaxLength(vectors);
max_vector.X = 0;
max_vector.Y = 0;

var max_vector2 = GetVectorWithMaxLength(vectors);

//GetRefVectorWithMaxLength(vectors).X = 123;

ref var max_vector3 = ref GetRefVectorWithMaxLength(vectors);
max_vector3.X = 0;
max_vector3.Y = 0;

ref var max_vector4 = ref GetRefVectorWithMaxLength(vectors);

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
    if (vector.X > 3)
        vector = default;
}

static void InitializeRandomVector(out Vector2D vector)
{
    vector = new(Random.Shared.NextDouble() * 100, Random.Shared.NextDouble() * 100);
}

static void PrintVector(in Vector2D vector)
{
    Console.WriteLine("Вектор x:{0}, y:{1}", vector.X, vector.Y);
}

static Vector2D GetVectorWithMaxLength(Vector2D[] vectors)
{
    var max_length = double.NegativeInfinity;
    Vector2D max_vector = default;

    for(var i = 0; i < vectors.Length; i++)
        if (vectors[i].Length > max_length)
        {
            max_length = vectors[i].Length;
            max_vector = vectors[i];
        }

    return max_vector;
}

static ref Vector2D GetRefVectorWithMaxLength(Vector2D[] vectors)
{
    var max_length = double.NegativeInfinity;
    var index = -1;

    for(var i = 0; i < vectors.Length; i++)
        if (vectors[i].Length > max_length)
        {
            max_length = vectors[i].Length;
            index = i;
        }

    return ref vectors[index];
}