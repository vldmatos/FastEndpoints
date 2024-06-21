namespace Configurations.Entities
{
    public class Product
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Category { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
