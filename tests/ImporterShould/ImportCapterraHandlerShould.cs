using Common.Data;
using Moq;
using Operations.Features.v1.ImportCapterra;
using Operations.Features.v1.ImportCapterra.Deserializer;
using Operations.Shared;

namespace ImporterShould
{
    public class ImportCapterraHandlerShould
    {
        private readonly Mock<IYamlDeserializer> _deserializerMock;
        private readonly Mock<IFileReader> _fileReaderMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Handler _handler;

        public ImportCapterraHandlerShould()
        {
            _fileReaderMock = new Mock<IFileReader>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _deserializerMock = new Mock<IYamlDeserializer>();
            _handler = new Handler(_fileReaderMock.Object, _deserializerMock.Object, _productRepositoryMock.Object);
        }

        [Fact]
        public async Task Return_ImportedProducts_When_Everything_Was_Successful()
        {
            _fileReaderMock.Setup(x=>x.ReadFileAsync(It.IsAny<string>(), default)).ReturnsAsync("string");
            _deserializerMock.Setup(x => x.Deserialize(It.IsAny<string>())).Returns(new List<Model>() { 
                new Model()
                {
                    Name = "Name",
                    Tags = "Tags",
                    Twitter = "Twitter"
                }
            });
            _productRepositoryMock.Setup(x => x.CreateBatch(It.IsAny<IEnumerable<ProductEntity>>())).Returns(Task.CompletedTask);
            
            var request = new ImportCapterraRequest();

            var response = await _handler.Handle(request, default);

            Assert.NotNull(response);
            Assert.NotEmpty(response.ImportedData);
        }

        [Fact]
        public async Task ThrowException_When_Invalid_Request_FilePath_Provided()
        {
            var request = new ImportCapterraRequest() {FilePath = "InvalidPath"};

            Task act() => _handler.Handle(request, default);

            await Assert.ThrowsAsync<InvalidOperationException>(() => act());
        }
    }
}