using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.Features.v1.ImportCapterra.Mappers
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
                productEntity.Title = product.Name;
                productEntity.Categories = product.Tags;
                entities.Add(productEntity);
            }

            return entities;
        }
    }
}
