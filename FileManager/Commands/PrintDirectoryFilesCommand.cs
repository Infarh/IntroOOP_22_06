using FileManager.Commands.Base;

namespace FileManager.Commands;

public class PrintDirectoryFilesCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public override string Description => "Вывод содержимого директории";

    public PrintDirectoryFilesCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        var directory = _FileManager.CurrentDirectory;
        _UserInterface.WriteLine($"Содержимое директории {directory}:");

        var dirs_count = 0;
        foreach (var sub_dir in directory.EnumerateDirectories())
        {
            _UserInterface.WriteLine($"    d    {sub_dir.Name}");
            dirs_count++;
        }

        var files_count = 0;
        long total_length = 0;
        foreach (var file in directory.EnumerateFiles())
        {
            _UserInterface.WriteLine($"    f    {file.Name}\t{file.Length}");
            files_count++;
            total_length += file.Length;
        }

        _UserInterface.WriteLine("");
        _UserInterface.WriteLine($"Директорий {dirs_count}, файлов {files_count} (суммарный размер {total_length} байт)");
    }
}
