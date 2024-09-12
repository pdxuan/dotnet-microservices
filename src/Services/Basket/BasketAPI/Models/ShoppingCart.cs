namespace BasketAPI.Models
{
    public class ShoppingCart
    {
        public Guid UserId { get; set; } = default!;
        public string UserName { get; set; } = default!;

        public List<ShoppingCartItem> Items { get; set; } = new();

        public decimal TotalPrice => Items.Sum(x => x.Price* x.Quantity);

        public ShoppingCart(Guid userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        //Required for Mapping
        public ShoppingCart()
        {
        }



    }
}
