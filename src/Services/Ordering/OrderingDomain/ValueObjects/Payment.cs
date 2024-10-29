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

        public string CardName { get; set; } = default!;

        public string CardNumber { get; set; } = default!;

        public string Expiration { get; set; } = default!;

        public string CVV { get; set; } = default!;

        public int PaymentMethod { get; set; } = default;

        protected Payment()
        {

        }


        private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            CVV = cvv;
            PaymentMethod = paymentMethod;
        }

        public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            ArgumentException.ThrowIfNullOrEmpty(cardName);
            ArgumentException.ThrowIfNullOrEmpty(cardNumber);
            ArgumentException.ThrowIfNullOrEmpty(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, CCV_MAXLENGTH);

            return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
        }

    }
}
