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


    }
}
