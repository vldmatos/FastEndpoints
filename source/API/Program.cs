
using Configurations.Data;
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
                            .AddSwaggerGen();

            var application = builder.Build();

            application.CreateDbIfNotExists();
            application.MapDefaultEndpoints();
            
            if (application.Environment.IsDevelopment())
            {
                application.UseSwagger();
                application.UseSwaggerUI();
            }

            application.UseHttpsRedirection()
                       .UseAuthorization()
                       .UseFastEndpoints();

            application.Run();
        }
    }
}