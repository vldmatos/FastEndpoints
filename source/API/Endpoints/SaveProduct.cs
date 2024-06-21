using Configurations.Data;
using FastEndpoints;

namespace API.Endpoints
{
    public class SaveProduct(DataContext dataContext) : Endpoint<Requests.Product, Responses.Product, Mappers.Product>
    {
        public override void Configure()
        {
            Put("product");
            AllowAnonymous();
        }

        public override Task HandleAsync(Requests.Product request, CancellationToken cancelationToken)
        {
            var product = Map.ToEntity(request);

            dataContext.Products.Add(product);
            dataContext.SaveChanges();

            Response = Map.FromEntity(product);

            return Task.CompletedTask;
        }
    }
}