namespace Infrastructure
{
    public abstract class BaseCommand : ICommand
    {
        public string FileName { get; set; }  // this depends on how or where do we get the file from
    }
}