namespace FileManager;

public class FileManagerLogic
{
    private readonly IUserInterface _UserInterface;

    public FileManagerLogic(IUserInterface UserInterface)
    {
        _UserInterface = UserInterface;


    }


    public void Start()
    {
        _UserInterface.WriteLine("Файловый менеджер v2.0");

        var can_work = true;
        do
        {
            var input = _UserInterface.ReadLine("> ", false);

            switch (input)
            {
                case "quit":
                    can_work = false;
                    break;

                case "int":
                    var int_value = _UserInterface.ReadInt("Введите целое число > ", false);
                    _UserInterface.WriteLine($"Введено: {int_value}");
                    break;

                case "double":
                    var double_value = _UserInterface.ReadDouble("Введите вещественное число > ", false);
                    _UserInterface.WriteLine($"Введено: {double_value}");
                    break;
            }
        }
        while (can_work);
    }
}
