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

            if (input == "quit")
                can_work = false;
            else
                _UserInterface.WriteLine($"Введена команда {input}");
        }
        while (can_work);
    }
}
