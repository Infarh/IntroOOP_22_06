using System.Xml.Serialization;
using IntroOOP.Students;

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

public class XmlStudentSerializer : StudentsSerializer
{
    private static readonly XmlSerializer __Serializer = new(typeof(Student[]));

    public override Student[] Deserialize(Stream stream)
    {
        return (Student[])__Serializer.Deserialize(stream)!;
    }

    public override void Serialize(Student[] value, Stream stream)
    {
        __Serializer.Serialize(stream, value);
    }
}