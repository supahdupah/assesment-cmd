using Common.Data;

namespace Operations.Features.v1.ImportCapterra.Mappers
{
    public class Mapper
    {
        public static IEnumerable<ProductEntity> MapToEntities(List<Model> models)
        {
            var entities = new List<ProductEntity>();
            foreach (var product in models)
            {
                ProductEntity productEntity = new ProductEntity();
                productEntity.Id = Guid.NewGuid();
                productEntity.Twitter = product.Twitter;
                productEntity.Title = product.Name;
                productEntity.Categories = product.Tags.Split(",");
                entities.Add(productEntity);
            }

            return entities;
        }
    }
}
