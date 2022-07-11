using System.Text;
using System.Xml;
using System.Xml.Serialization;
using IntroOOP.Students;

namespace IntroOOP.Infrastructure;

public class XmlDataSerializer<T> : DataSerializer<T>
{
    private static readonly XmlSerializer __Serializer = new(typeof(T));

    public bool WriteIdent { get; set; }

    public override T Deserialize(Stream stream)
    {
        return (T)__Serializer.Deserialize(stream)!;
    }

    public override void Serialize(T value, Stream stream)
    {
        if (WriteIdent)
        {
            var writer = new XmlTextWriter(stream, Encoding.UTF8) { Formatting = Formatting.Indented };
            __Serializer.Serialize(writer, value);
        }
        else
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