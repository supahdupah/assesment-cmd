using Operations.Shared;

namespace Operations.Tests
{
    public class FileReaderShould
    {
        private readonly FileReader _fileReader;
        public FileReaderShould()
        {
            _fileReader = new FileReader();
        }

        [Theory]
        [InlineData("TestMockFiles/capterra.yaml", "Slack")]
        [InlineData("TestMockFiles/softwareadvice.json", "CRM")]
        public async Task Return_String_Content_Given_Valid_Path(string filePath, string expectedToContainString)
        {
            var path = Path.GetFullPath(filePath);
            var result = await _fileReader.ReadFileAsync(path, default);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains(expectedToContainString, result);
        }
    }
}
