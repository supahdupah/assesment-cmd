namespace Operations.Features.v1.ImportCapterra.Deserializer
{
    public interface IYamlDeserializer
    {
        Model Deserialize(string content);
    }
}
