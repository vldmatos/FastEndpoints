
using Configurations.Data;
using Configurations.Extensions;
using FastEndpoints;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();

            builder.AddNpgsqlDbContext<DataContext>("products");
            
            builder.Services.AddAuthorization()
                            .AddEndpointsApiExplorer()
                            .AddFastEndpoints()
                            .AddSwagger();

            var application = builder.Build();

            application.CreateDbIfNotExists();
            application.MapDefaultEndpoints();
            
            application.UseSwagger();
            application.UseSwaggerUI();
            

            application.UseHttpsRedirection()
                       .UseAuthorization()
                       .UseFastEndpoints();

            application.Run();
        }
    }
}