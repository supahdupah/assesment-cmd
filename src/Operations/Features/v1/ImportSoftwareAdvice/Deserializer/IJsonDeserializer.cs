namespace Operations.Features.v1.ImportSoftwareAdvice.Deserializer
{
    public interface IJsonDeserializer
    {
        Model Deserialize(string content);
    }
}
