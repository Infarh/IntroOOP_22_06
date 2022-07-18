using FileManager.Commands;
using FileManager.Commands.Base;

namespace FileManager;

public class FileManagerLogic
{
    private readonly IUserInterface _UserInterface;

    public DirectoryInfo CurrentDirectory { get; set; } = new("c:\\");

    public IReadOnlyDictionary<string, FileManagerCommand> Commands { get; }

    public FileManagerLogic(IUserInterface UserInterface)
    {
        _UserInterface = UserInterface;

        var list_dir_command = new PrintDirectoryFilesCommand(UserInterface, this);
        Commands = new Dictionary<string, FileManagerCommand>
        {
            { "drives", new ListDrivesCommand(UserInterface) },
            { "dir", list_dir_command },
            { "ListDir", list_dir_command },
        };
    }


    public void Start()
    {
        _UserInterface.WriteLine("Файловый менеджер v2.0");

        var can_work = true;
        do
        {
            var input = _UserInterface.ReadLine("> ", false);

            var args = input.Split(' ');
            var command_name = args[0];

            if (command_name == "quit") // todo: реализовать в виде команды
            {
                can_work = false;
                continue;
            }

            if (!Commands.TryGetValue(command_name, out var command))
            {
                _UserInterface.WriteLine($"Неизвестная команда {command_name}.");
                _UserInterface.WriteLine("Для справки введите help, для выхода quit");
                continue;
            }

            try
            {
                command.Execute(args);
            }
            catch (Exception error)
            {
                _UserInterface.WriteLine($"При выполнении команды {command_name} произошла ошибка:");
                _UserInterface.WriteLine(error.Message);
            }
        }
        while (can_work);
    }
}
