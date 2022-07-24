using Infrastructure;
using MediatR;
using Newtonsoft.Json;
using Operations.Features.v1.ImportSoftwareAdvice.Deserializer;
using Operations.Shared;

namespace Operations.Features.v1.ImportSoftwareAdvice
{
    public class Handler : IRequestHandler<ImportSoftwareAdviceRequest, ImportSoftwareAdviceResponse>
    {
        private readonly IFileReader _fileReader;
        private readonly IJsonDeserializer _jsonDeserializer;
        private readonly IProductRepository _repository;

        public Handler(IFileReader fileReader, IJsonDeserializer jsonDeserializer, IProductRepository repository)
        {
            _fileReader = fileReader;
            _jsonDeserializer = jsonDeserializer;
            _repository = repository;
        }

        //without knowing full requirements many things could be done differently
        public async Task<ImportSoftwareAdviceResponse> Handle(ImportSoftwareAdviceRequest request, CancellationToken cancellationToken)
        {
            var stringResult = await _fileReader.ReadFileAsync(request.FilePath, cancellationToken);
            if (stringResult == null)
                throw new InvalidOperationException();

            var model = _jsonDeserializer.Deserialize(stringResult);
            var entities = Mappers.Mapper.MapToEntities(model);

            await _repository.CreateBatch(entities);

            return new ImportSoftwareAdviceResponse()
            {
                ImportedData = JsonConvert.SerializeObject(entities)
            };
        }
    }
}
