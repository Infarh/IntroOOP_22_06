using IntroOOP.Transport;

Car car1 = new Car("Лада Гранта", 100, 35);
//car1.SetX(5);
//car1.Speed = 7;
car1.X = 6;
car1.Speed = 7;


var car2 = new Car();
car2.SetX(7);
car2.SetSpeed(3);

const double T = 60;
const double dt = 0.1;
for (var t = 0.0; t < T; t += dt)
{
    car1.Move(dt);
    car2.Move(dt);

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