using IntroOOP.Transport;

Car car1 = new Car();
//car1.SetX(5);
//car1.X = 5;
//car1.Speed = 7;
car1.X = 6;
car1.Speed = 7;


var car2 = new Car();
car2.SetX(7);
car2.SetSpeed(3);

Console.WriteLine("Скорость машины №2 = {0}", car2.GetSpeed());
//car2.X = 10;
//car2.Speed = 3;


Console.WriteLine("Программа завершена.");
Console.ReadLine();