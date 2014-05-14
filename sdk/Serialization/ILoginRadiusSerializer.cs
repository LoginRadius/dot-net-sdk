namespace LoginRadius.SDK.Serialization
{
    internal interface ILoginRadiusSerializer<T> where T : class, new()
    {
        string Serialize(T data);
        T Deserialize(string content);
    }
}
