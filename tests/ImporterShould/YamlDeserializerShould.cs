using Microsoft.Extensions.Logging;
using Moq;
using Operations.Features.v1.ImportCapterra.Deserializer;

namespace Operations.Tests
{
    public class YamlDeserializerShould
    {
        private readonly Mock<ILogger<YamlDeserializer>> _loggerMock;
        private readonly YamlDeserializer _yamlDeserializer;
        public YamlDeserializerShould()
        {
            _loggerMock = new Mock<ILogger<YamlDeserializer>>();
            _yamlDeserializer = new YamlDeserializer(_loggerMock.Object);
        }

        [Fact]
        public void Return_Valid_Model_Object()
        {
            var validYamlString = @"---
-
  tags: ""Bugs & Issue Tracking,Development Tools""
  name: ""GitGHub""
  twitter: ""github""
-
  tags: ""Instant Messaging & Chat,Web Collaboration,Productivity""
  name: ""Slack""
  twitter: ""slackhq""
-
  tags: ""Project Management,Project Collaboration,Development Tools""
  name: ""JIRA Software""
  twitter: ""jira""";

            var result = _yamlDeserializer.Deserialize(validYamlString);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count() == 3);
            Assert.Contains(result, x => x.Twitter== "jira");
            Assert.Contains(result, x => x.Twitter == "github");
        }
    }
}
