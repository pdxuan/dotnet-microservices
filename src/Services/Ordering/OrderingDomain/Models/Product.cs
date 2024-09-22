

namespace OrderingDomain.Models
{
    public class Product : Entity<ProductId>
    {
        public string Name { get; private set; } = default!;

        public decimal Price { get; private set; } = default!;

        public string? Description { get; private set; }
    }
}
