using System.Runtime.Serialization.Formatters.Binary;
using IntroOOP.Students;

namespace IntroOOP.Infrastructure;

public class BinaryDataSerializer<T> : DataSerializer<T>
{
    private static readonly BinaryFormatter __Serializer = new();

    public override void Serialize(T value, Stream stream)
    {
        __Serializer.Serialize(stream, value);
    }

    public override T Deserialize(Stream stream)
    {
        return (T)__Serializer.Deserialize(stream);
    }
}

public class BinaryStudentSerializer : StudentsSerializer
{
    private static readonly BinaryFormatter __Serializer = new();

    public override void Serialize(Student[] value, Stream stream)
    {
        __Serializer.Serialize(stream, value);
    }

    public override Student[] Deserialize(Stream stream)
    {
        return (Student[])__Serializer.Deserialize(stream);
    }
}