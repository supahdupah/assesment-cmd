namespace Infrastructure
{
    // requirements do not indicate anything regarding data models or databases or structure so this is left as a basic
    public class ProductRepository : IProductRepository
    {
        public Task Create(ProductEntity entity)
        {
            return Task.CompletedTask;
        }

        public Task CreateBatch(IEnumerable<ProductEntity> entities)
        {
            return Task.CompletedTask;
        }
    }
}
