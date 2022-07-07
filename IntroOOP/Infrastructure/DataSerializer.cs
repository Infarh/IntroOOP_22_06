using IntroOOP.Students;

namespace IntroOOP.Infrastructure;

public abstract class DataSerializer<T>
{
    public abstract void Serialize(T value, Stream stream);

    public abstract T Deserialize(Stream stream);

    public static explicit operator DataSerializer<T>(string SerializerName)
    {
        switch (SerializerName)
        {
            case "xml":
                return new XmlDataSerializer<T>();
            case "json":
                return new JsonDataSerializer<T>();
            case "bin":
                return new BinaryDataSerializer<T>();

            default: throw new NotSupportedException($"Неизвестный тип сериализатора {SerializerName}");
        }
    }
}

public abstract class StudentsSerializer : DataSerializer<Student[]>
{
    public static implicit operator StudentsSerializer(string SerializerName)
    {
        switch (SerializerName)
        {
            case "xml":
                return new XmlStudentSerializer();
            case "json":
                return new JsonStudentSerializer();
            case "bin":
                return new BinaryStudentSerializer();

            default: throw new NotSupportedException($"Неизвестный тип сериализатора {SerializerName}");
        }
    }
}