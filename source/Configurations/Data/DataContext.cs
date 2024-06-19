using Configurations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Configurations.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = default!;
    }

    public static class DbExtensions
    { 
        public static void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DataContext>();

            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }

    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new () { Name = "Product 1", Price = 1.99m },
                new () { Name = "Product 2", Price = 2.99m },
                new () { Name = "Product 3", Price = 3.99m },
                new () { Name = "Product 4", Price = 4.99m },
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}