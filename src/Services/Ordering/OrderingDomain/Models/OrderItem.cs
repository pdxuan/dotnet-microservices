
namespace OrderingDomain.Models
{
    public class OrderItem : Entity<OrderItemId>
    {

        internal OrderItem(OrderId orderId, ProductId productId, int quantity, decimal price) { 
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public OrderId OrderId { get; set; } = default!;

        public ProductId ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
