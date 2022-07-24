using Microsoft.Extensions.Logging;
using YamlDotNet.Serialization.NamingConventions;

namespace Operations.Features.v1.ImportCapterra.Deserializer
{
    public class YamlDeserializer : IYamlDeserializer
    {
        private readonly ILogger<YamlDeserializer> _logger;

        public YamlDeserializer(ILogger<YamlDeserializer> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public List<Model> Deserialize(string content)
        {
            try
            {
                var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var result = deserializer.Deserialize<List<Model>>(content);
                _logger.LogDebug("Successful Yaml deserialization");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
