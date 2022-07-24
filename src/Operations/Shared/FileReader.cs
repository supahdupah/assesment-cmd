using System.Diagnostics;

namespace Operations.Shared
{
    public class FileReader : IFileReader
    {
        public async Task<string> ReadFileAsync(string filePath, CancellationToken cancellationToken)
        {
            try
            {
                var result = await File.ReadAllTextAsync(filePath, cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                throw;
            }
        }
    }

    public interface IFileReader
    {
        Task<string> ReadFileAsync(string filePath, CancellationToken cancellationToken);
    }
}
