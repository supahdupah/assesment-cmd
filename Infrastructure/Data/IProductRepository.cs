namespace Common.Data
{
    // requirements do not indicate anything regarding data models or databases or structure so this is left as a basic
    public interface IProductRepository
    {
        Task Create(ProductEntity entity);
        Task CreateBatch(IEnumerable<ProductEntity> entities);
        //etc
    }
}