using Microsoft.Extensions.Logging;
using Moq;
using Operations.Features.v1.ImportSoftwareAdvice.Deserializer;

namespace Operations.Tests
{
    public class JsonDeserializerShould
    {
        private readonly Mock<ILogger<JsonDeserializer>> _loggerMock;
        private readonly JsonDeserializer _jsonDeserializer;
        public JsonDeserializerShould()
        {
            _loggerMock = new Mock<ILogger<JsonDeserializer>>();
            _jsonDeserializer = new JsonDeserializer(_loggerMock.Object);
        }

        [Fact]
        public void Return_Valid_Model_Object()
        {
            var validJsonString = @"{""products"": [
        {
            ""categories"": [
                ""Customer Service"",
                ""Call Center""
            ],
            ""twitter"": ""@freshdesk"",
            ""title"": ""Freshdesk""
        },
        {
            ""categories"": [
                ""CRM"",
                ""Sales Management""
            ],
            ""title"": ""Zoho""
        }
    ]
}
";
            var result = _jsonDeserializer.Deserialize(validJsonString);

            Assert.True(result.Products.Count() == 2);
            Assert.NotEmpty(result.Products);
            Assert.Contains(result.Products, x => x.Title == "Freshdesk");
            Assert.Contains(result.Products, x => x.Title == "Zoho");
        }
    }
}
