using MediatR;
using Newtonsoft.Json;
using Operations.Shared;

namespace Operations.Features.v1.ImportSoftwareAdvice
{
    public class Handler : IRequestHandler<ImportSoftwareAdviceRequest, ImportSoftwareAdviceResponse>
    {
        private readonly IFileReader _fileReader;

        public Handler(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public async Task<ImportSoftwareAdviceResponse> Handle(ImportSoftwareAdviceRequest request, CancellationToken cancellationToken)
        {
            var result = await _fileReader.ReadFileAsync(request.FilePath, cancellationToken);
            if (result == null) ;
            //parse/deserialise
            //insert to db
            throw new NotImplementedException();
        }
    }

    public class Parser
    {
        public Model Deserialise(string content)
        {
            var result = JsonConvert.DeserializeObject<Model>(content);
            return result;
        }
    }
}
