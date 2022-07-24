using Infrastructure;
using MediatR;

namespace Operations.Features.v1.ImportSoftwareAdvice
{
    public class ImportSoftwareAdviceRequest : IRequest<ImportSoftwareAdviceResponse>
    {
        public string FilePath { get; set; }
    }
}
