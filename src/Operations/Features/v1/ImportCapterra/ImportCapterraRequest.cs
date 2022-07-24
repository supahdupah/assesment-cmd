using MediatR;

namespace Operations.Features.v1.ImportCapterra
{
    public class ImportCapterraRequest : IRequest<ImportCapterraResponse>
    {
        public string FilePath { get; set; }
    }
}
