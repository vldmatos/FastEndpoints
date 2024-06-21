using Configurations.Entities;
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

            var createAt = DateTime.UtcNow;

            var products = new Product[]
            {
                new () { Id = Guid.NewGuid().ToString(), Name = "Product 1", Category = "Category 1", Price = 100.99m, CreateAt = createAt },
                new () { Id = Guid.NewGuid().ToString(), Name = "Product 2", Category = "Category 1", Price = 20.99m,  CreateAt = createAt },
                new () { Id = Guid.NewGuid().ToString(), Name = "Product 3", Category = "Category 1", Price = 35.99m,  CreateAt = createAt },
                new () { Id = Guid.NewGuid().ToString(), Name = "Product 4", Category = "Category 2", Price = 55.99m,  CreateAt = createAt }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}