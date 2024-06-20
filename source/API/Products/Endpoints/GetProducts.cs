using Configurations.Data;
using Configurations.Models;
using FastEndpoints;

namespace API.Products.Endpoints
{
    public class GetProducts(DataContext dataContext) : EndpointWithoutRequest<IEnumerable<Product>>
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
