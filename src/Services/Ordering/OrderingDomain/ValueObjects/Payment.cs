using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingDomain.ValueObjects
{
    public record Payment
    {
        public string CartName { get; set; } = default!;

        public string CartNumber { get; set; } = default!;

        public string Expiration { get; set; } = default!;

        public string CVV { get; set; } = default!;

        public int PaymentMethod { get; set; } = default;
    }
}
