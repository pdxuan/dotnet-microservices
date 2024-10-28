
namespace OrderingDomain.Models
{
    public class Order : Aggregate<OrderId>
    {
        private readonly List<OrderItem> _orderItems = new();

        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public CustomerId CustomerId { get; private set; } = default!;

        public OrderName OrderName { get; private set; } = default!;

        public Address ShippingAddress { get; private set; } = default!;

        public Address BuillingAddress { get; private set; } = default!;

        public Payment Payment { get; private set; } = default!;

        public OrderStatus Status { get; private set; } = OrderStatus.Pending;


        public decimal TotalPrice
        {
            get => OrderItems.Sum(item => item.Price * item.Quantity);
            private set { }
        }



        public static Order Create(OrderId id, CustomerId customerId, OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment)
        {

            var order = new Order
            {
                Id = id,
                CustomerId = customerId,
                OrderName = orderName,
                ShippingAddress = shippingAddress,
                BuillingAddress = billingAddress,
                Payment = payment,
                Status = OrderStatus.Pending
            };



            //order.AddDomainEvent(new OrderCreatedEvent(order));

            return order;

        }

        public void Update(OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status)
        {
            OrderName = orderName;
            ShippingAddress = shippingAddress;
            BuillingAddress = billingAddress;
            Payment = payment;
            Status = status;


            //AddDomainEvent(new OrderUpdatedEvent(this));
        }



    }
}
