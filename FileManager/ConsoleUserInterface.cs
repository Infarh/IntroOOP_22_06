namespace FileManager;

public class ConsoleUserInterface : IUserInterface
{
    public void Write(string str)
    {
        Console.Write(str);
    }

    public void WriteLine(string str)
    {
        Console.WriteLine(str);
    }

    public string ReadLine(string? Prompt, bool PromptNewLine = true)
    {
        //if(Prompt != null && Prompt.Length > 0)
        if (Prompt is { Length: > 0 })
            if (PromptNewLine)
                WriteLine(Prompt);
            else
                Write(Prompt);

        return Console.ReadLine()!;
    }
}
