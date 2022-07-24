using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Operations.Features.v1.ImportSoftwareAdvice.Deserializer
{
    public class JsonDeserializer : IJsonDeserializer
    {
        private readonly ILogger<JsonDeserializer> _logger;

        public JsonDeserializer(ILogger<JsonDeserializer> logger)
        {
            _logger = logger;
        }

        public Model Deserialize(string content)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<Model>(content);
                _logger.LogDebug("Successful deserialization");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
