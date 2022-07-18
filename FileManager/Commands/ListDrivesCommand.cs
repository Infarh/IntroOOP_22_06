using FileManager.Commands.Base;

namespace FileManager.Commands;

public class ListDrivesCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    public override string Description => "Вывод списка дисков в системе";

    public ListDrivesCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;

    public override void Execute(string[] args)
    {
        var drives = DriveInfo.GetDrives();

        _UserInterface.WriteLine($"В файловой системе существует дисков: {drives.Length}");

        foreach (var drive in drives)
            _UserInterface.WriteLine($"    {drive.Name}");
    }
}