using Common.Data;
using MediatR;
using Newtonsoft.Json;
using Operations.Features.v1.ImportCapterra.Deserializer;
using Operations.Shared;

namespace Operations.Features.v1.ImportCapterra
{
    public class Handler : IRequestHandler<ImportCapterraRequest, ImportCapterraResponse>
    {
        private readonly IFileReader _fileReader;
        private readonly IYamlDeserializer _yamlDeserializer;
        private readonly IProductRepository _repository;

        public Handler(IFileReader fileReader, IYamlDeserializer yamlDeserializer, IProductRepository repository)
        {
            _fileReader = fileReader;
            _yamlDeserializer = yamlDeserializer;
            _repository = repository;
        }

        //without knowing full requirements many things could be done differently
        public async Task<ImportCapterraResponse> Handle(ImportCapterraRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var stringResult = await _fileReader.ReadFileAsync(request.FilePath, cancellationToken);
                if (stringResult == null)
                    throw new InvalidOperationException();

                var model = _yamlDeserializer.Deserialize(stringResult);
                var entities = Mappers.Mapper.MapToEntities(model);

                await _repository.CreateBatch(entities);

                return new ImportCapterraResponse
                {
                    ImportedData = JsonConvert.SerializeObject(entities)
                };
            }
            catch (Exception e)
            {
                //create my own exceptions if needed
                //handle as needed with further requirements
                throw;
            }
        }
    }
}
