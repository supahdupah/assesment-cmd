using Infrastructure;

namespace Operations.Features.v1.ImportCapterra
{
    public class Handler : IHandler<Command>
    {
        public Task HandleAsync(Command command, CancellationToken cancellationToken = default)
        {
            //    //validate file
            //    //read
            //    //parse
            //    //insert to db
            throw new NotImplementedException();
        }
    }
}
