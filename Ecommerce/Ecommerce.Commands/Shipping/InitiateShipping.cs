using NServiceBus;
using System;

namespace Ecommerce.Commands.Shipping
{
    public class InitiateShipping : ICommand
    {
        public Guid TransactionId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
