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
        /// CURRENTLY NOT WORKING
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public Model Deserialize(string content)
        {
            //not working and returning const data.
            try
            {
                var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                _logger.LogDebug("Successful Yaml deserialization");

                return new Model() { Products = new List<Product>() { 
                    new Product()
                    {
                        Name = "Random name",
                        Tags = new List<string>(){"Random tag" },
                        Twitter = "Random twitter"
                    }
                } };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
