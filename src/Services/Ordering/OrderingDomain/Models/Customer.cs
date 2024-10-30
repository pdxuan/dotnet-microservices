
namespace OrderingDomain.Models
{
    public class Customer : Entity<CustomerId>
    {
        public string Name { get; private set; } = default!;

        public string Email { get; private set; } = default!;



        /// <summary>
        /// Factory method 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Customer Create(CustomerId id, string name, string email)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(email);
             
            var customer = new Customer { Id = id, Name = name, Email = email };

            return customer;
        }
    }
}
