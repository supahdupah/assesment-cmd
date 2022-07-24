namespace Operations.Shared
{
    public interface IFileReader
    {
        Task<string> ReadFileAsync(string filePath, CancellationToken cancellationToken);
    }
}
