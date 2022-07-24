namespace Operations.Features.v1.ImportCapterra.Deserializer
{
    public interface IYamlDeserializer
    {
        List<Model> Deserialize(string content);
    }
}
