using FastEndpoints;
using Entities = Configurations.Entities;

namespace API.Mappers
{
    public class Product : Mapper<Requests.Product, Responses.Product, Entities.Product>
    {
        public override Entities.Product ToEntity(Requests.Product request) => new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Category = request.Category,
            Price = request.Price,
            CreateAt = DateTime.UtcNow
        };

        public override Responses.Product FromEntity(Entities.Product entity) => new()
        {
            Name = entity.Name,
            Category = entity.Category,
            Price = entity.Price
        };
    }
}