namespace Operations.Features.v1.ImportSoftwareAdvice
{
    public class Model
    {
        public IEnumerable<Product> Products { get; set; }
    }

    public class Product
    {
        public string[] Categories { get; set; }
        public string Twitter { get; set; }
        public string Title { get; set; }
    }
}
