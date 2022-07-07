using System.Xml.Serialization;

namespace IntroOOP.Infrastructure;

public class XmlDataSerializer<T> : DataSerializer<T>
{
    private static readonly XmlSerializer __Serializer = new(typeof(T));

    public override T Deserialize(Stream stream)
    {
        return (T)__Serializer.Deserialize(stream)!;
    }

    public override void Serialize(T value, Stream stream)
    {
        __Serializer.Serialize(stream, value);
    }
}