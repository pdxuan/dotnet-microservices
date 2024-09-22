
namespace OrderingDomain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; set; } = default!; 

        public string Lastname { get; set; } = default!;

        public string? EmailAdress { get; set; }

        public string AddressLine { get; set; } = default!;

        public string Country { get; set; } = default!;

        public string City { get; set; } = default!;

        public string ZipCode { get; set; } = default!;
    }
}
