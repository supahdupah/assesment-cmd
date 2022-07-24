using Infrastructure;

namespace Operations.Features.v1.ImportSoftwareAdvice.Mappers
{
    public class Mapper
    {
        public static IEnumerable<ProductEntity> MapToEntities(Model model)
        {
            var entities = new List<ProductEntity>();
            foreach (var product in model.Products)
            {
                ProductEntity productEntity = new ProductEntity();
                productEntity.Id = Guid.NewGuid();
                productEntity.Twitter = product.Twitter;
                productEntity.Title = product.Title;
                productEntity.Categories = product.Categories;
                entities.Add(productEntity);
            }

            return entities;
        }
    }
}
