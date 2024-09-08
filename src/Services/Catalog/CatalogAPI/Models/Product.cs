namespace CatalogAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public List<string> Category { get; set; } = new();

        public string? ImageFile { get; set; }

        public decimal Price { get; set; }
    }
}
