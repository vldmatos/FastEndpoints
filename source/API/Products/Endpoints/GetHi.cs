using FastEndpoints;

namespace API.Products.Endpoints
{
    public class GetHi : EndpointWithoutRequest<String>
    {
        public override void Configure()
        {
            Get("hi");
            AllowAnonymous();
        }

        public override Task HandleAsync(CancellationToken cancelationToken)
        {
            Response = "Hi!";
            return Task.CompletedTask;
        }
    }
}
