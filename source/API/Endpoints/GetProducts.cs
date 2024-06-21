using Configurations.Data;
using FastEndpoints;
using Entities = Configurations.Entities;

namespace API.Endpoints
{
    public class GetProducts(DataContext dataContext) : EndpointWithoutRequest<IEnumerable<Entities.Product>>
    {
        public override void Configure()
        {
            Get("products");
            AllowAnonymous();
        }

        public override Task HandleAsync(CancellationToken cancelationToken)
        {
            Response = [.. dataContext.Products];

            return Task.CompletedTask;
        }
    }
}