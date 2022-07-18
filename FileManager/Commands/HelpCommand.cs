using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Commands.Base;

namespace FileManager.Commands;

public class HelpCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public override string Description => "Помощь";

    public HelpCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        _UserInterface.WriteLine("Файловый менеджер поддерживает следующие команды:");

        foreach (var (name, command) in _FileManager.Commands)
            _UserInterface.WriteLine($"    {name}\t{command.Description}");
    }
}
