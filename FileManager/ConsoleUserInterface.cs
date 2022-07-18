namespace FileManager;

public class ConsoleUserInterface : IUserInterface
{
    public void WriteLine(string str)
    {
        Console.WriteLine(str);
    }

    public string ReadLine(string? Prompt)
    {
        //if(Prompt != null && Prompt.Length > 0)
        if(Prompt is { Length: > 0 })
            WriteLine(Prompt);

        return Console.ReadLine()!;
    }
}
