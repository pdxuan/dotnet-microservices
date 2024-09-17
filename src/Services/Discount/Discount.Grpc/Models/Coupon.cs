namespace Discount.Grpc.Models
{
    public class Coupon
    {
        public int Id { get; set; }

        public required string ProductName { get; set; }

        public string? Description { get; set; } = default;

        public int Amount { get; set; }
    }
}
