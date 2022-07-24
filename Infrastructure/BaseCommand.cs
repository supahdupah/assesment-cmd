namespace Infrastructure
{
    public abstract class BaseCommand : ICommand
    {
        public string FilePath { get; set; }  // this depends on how or where do we get the file from
    }
}