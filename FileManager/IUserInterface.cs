namespace FileManager;

public interface IUserInterface
{
    void Write(string str);

    void WriteLine(string str);

    string ReadLine(string? Prompt, bool PromptNewLine = true);

    int ReadInt(string? Prompt, bool PromptNewLine = true);

    double ReadDouble(string? Prompt, bool PromptNewLine = true);
}
