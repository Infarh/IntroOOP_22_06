namespace IntroOOP.Infrastructure;

public abstract class DataSerializer<T>
{
    public abstract void Serialize(T value, Stream stream);

    public abstract T Deserialize(Stream stream);
}