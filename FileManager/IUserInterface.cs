namespace FileManager;

public interface IUserInterface
{
    void Write(string str);

    void WriteLine(string str);

    string ReadLine(string? Prompt, bool PromptNewLine = true);
}
