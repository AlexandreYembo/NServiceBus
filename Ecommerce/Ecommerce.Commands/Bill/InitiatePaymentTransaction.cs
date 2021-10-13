 using System;
using NServiceBus;

namespace Ecommerce.Commands.Bill
{
    public class InitiatePaymentTransaction : ICommand
    {
        public Guid TransactionId { get; set; }
        public decimal Price { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }

    public class PaymentDetails
    {
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string MonthExpire { get; set; }
        public string YearExpire { get; set; }
    }
}
