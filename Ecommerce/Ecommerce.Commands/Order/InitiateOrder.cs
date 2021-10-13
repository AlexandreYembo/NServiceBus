using System;
using Ecommerce.Commands.Bill;
using Ecommerce.Commands.Shipping;
using NServiceBus;

namespace Ecommerce.Commands.Order
{
    public class InitiateOrder: ICommand
    {
        public Guid TransactionId { get; set; }
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        public Address Address { get; set; }
    }

}
