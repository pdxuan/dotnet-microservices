

namespace OrderingDomain.Models
{
    public class Product : Entity<ProductId>
    {
        public string Name { get; private set; } = default!;

        public decimal Price { get; private set; } = default!;

        public string? Description { get; private set; }


        public static Product Create(ProductId id, string name, decimal price, string description)
        {

            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);


             var product = new Product { Id = id, Name = name, Price = price, Description = description};
            return product;
        }
    }
}
