using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using IntroOOP.Students;

namespace IntroOOP.Infrastructure;

public class JsonDataSerializer<T> : DataSerializer<T>
{
    public bool WriteIdent { get; set; }

    public override void Serialize(T value, Stream stream)
    {
        if (WriteIdent)
            JsonSerializer.Serialize(stream, value, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            });
        else
            JsonSerializer.Serialize(stream, value);
    }

    public override T Deserialize(Stream stream)
    {
        return JsonSerializer.Deserialize<T>(stream)!;
    }
}

public class JsonStudentSerializer : StudentsSerializer
{
    public bool WriteIdent { get; set; }

    public override void Serialize(Student[] value, Stream stream)
    {
        if (WriteIdent)
            JsonSerializer.Serialize(stream, value, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            });
        else
            JsonSerializer.Serialize(stream, value);
    }

    public override Student[] Deserialize(Stream stream)
    {
        return JsonSerializer.Deserialize<Student[]>(stream)!;
    }
}