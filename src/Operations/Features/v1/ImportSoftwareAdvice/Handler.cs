using Infrastructure;
using Newtonsoft.Json;
using Operations.Shared;

namespace Operations.Features.v1.ImportSoftwareAdvice
{
    public class Handler : IHandler<Command>
    {
        private readonly IFileReader _fileReader;

        public Handler(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        public async Task HandleAsync(Command command, CancellationToken cancellationToken = default)
        {
            var result = await _fileReader.ReadFileAsync(command.FileName, cancellationToken);
            if (result == null) ;

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
