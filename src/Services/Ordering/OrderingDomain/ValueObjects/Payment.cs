using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingDomain.ValueObjects
{
    public record Payment
    {

        private const int CCV_MAXLENGTH = 3;

        public string CartName { get; set; } = default!;

        public string CartNumber { get; set; } = default!;

        public string Expiration { get; set; } = default!;

        public string CVV { get; set; } = default!;

        public int PaymentMethod { get; set; } = default;

        protected Payment()
        {

        }


        private Payment(string cartName, string cartNumber, string expiration, string cvv, int paymentMethod)
        {
            CartName = cartName;
            CartNumber = cartNumber;
            Expiration = expiration;
            CVV = cvv;
            PaymentMethod = paymentMethod;
        }

        public static Payment Of(string cartName, string cartNumber, string expiration, string cvv, int paymentMethod)
        {
            ArgumentException.ThrowIfNullOrEmpty(cartName);
            ArgumentException.ThrowIfNullOrEmpty(cartNumber);
            ArgumentException.ThrowIfNullOrEmpty(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, CCV_MAXLENGTH);

            return new Payment(cartName, cartNumber, expiration, cvv, paymentMethod);
        }

    }
}
