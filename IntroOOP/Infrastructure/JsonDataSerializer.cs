using System.Text.Json;

namespace IntroOOP.Infrastructure;

public class JsonDataSerializer<T> : DataSerializer<T>
{
    public override void Serialize(T value, Stream stream)
    {
        JsonSerializer.Serialize(stream, value);
    }

    public override T Deserialize(Stream stream)
    {
        return JsonSerializer.Deserialize<T>(stream)!;
    }
}