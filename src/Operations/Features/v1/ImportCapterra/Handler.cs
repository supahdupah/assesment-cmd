using Infrastructure;
using MediatR;

namespace Operations.Features.v1.ImportCapterra
{
    public class Handler : IRequestHandler<ImportCapterraRequest, ImportCapterraResponse>
    {
        public Task<ImportCapterraResponse> Handle(ImportCapterraRequest request, CancellationToken cancellationToken)
        {
            //    //validate file
            //    //read
            //    //parse
            //    //insert to db
            throw new NotImplementedException();
        }
    }
}
