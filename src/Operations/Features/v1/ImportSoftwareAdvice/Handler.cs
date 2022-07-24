using Infrastructure;

namespace Operations.Features.v1.ImportSoftwareAdvice
{
    public class Handler : IHandler<Command>
    {
        public Task HandleAsync(Command command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
