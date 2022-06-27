using IntroOOP;
using IntroOOP.Transport;

Car car1 = new Car("Лада Гранта", new Vector2D(-100, 0), new Vector2D());
//car1.SetX(5);
//car1.Speed = 7;
//car1.X = 6;
//car1.Speed = 7;


var car2 = new Car("Грузовик", new Vector2D(30, 0), new Vector2D(10, 0));
//car2.SetX(30);
//car2.SetSpeed(10);

const double T = 60;
const double dt = 0.1;
for (var t = 0.0; t < T; t += dt)
{
    car1.Move(dt);
    car2.Move(dt);

    car1.Acceleration = new Vector2D(1 / (1 + Math.Exp(-(t - 5) / 2)), 0);

    Console.WriteLine("t = {0:f1}", t);

    car1.PrintPosition();
    car2.PrintPosition();

    Console.WriteLine();
}

//Console.WriteLine("Скорость машины №2 = {0}", car2.GetSpeed());
//car2.X = 10;
//car2.Speed = 3;


Console.WriteLine("Программа завершена.");
Console.ReadLine();