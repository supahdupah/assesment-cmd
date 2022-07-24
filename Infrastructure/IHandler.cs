namespace Infrastructure
{
    public interface IHandler<T> where T : ICommand
    {
        Task HandleAsync(T command, CancellationToken cancellationToken = default);
    }
}
