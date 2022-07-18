namespace FileManager.Commands.Base;

public abstract class FileManagerCommand
{
    public abstract string Description { get; }

    public abstract void Execute(string[] args);
}
