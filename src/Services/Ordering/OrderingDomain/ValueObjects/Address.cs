
namespace OrderingDomain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; set; } = default!; 

        public string LastName { get; set; } = default!;

        public string? EmailAddress { get; set; }

        public string AddressLine { get; set; } = default!;

        public string Country { get; set; } = default!;

        public string City { get; set; } = default!;

        public string ZipCode { get; set; } = default!;



        protected Address()
        {

        }


        private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string city, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            City = city;
            ZipCode = zipCode;
        }


        public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string city, string zipCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(emailAddress);
            ArgumentException.ThrowIfNullOrEmpty(addressLine);


            return new Address(firstName, lastName, emailAddress, addressLine, country, city, zipCode);
        }

    }
}
