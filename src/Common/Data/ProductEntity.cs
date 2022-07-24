namespace Common.Data
{
    // here depends if the ProductEntity is shared between all sources imports
    // usually i would move this out to nuget package or somewhere else where it could be shared if needed
    public class ProductEntity : EntityBase
    {
        public string Twitter { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
