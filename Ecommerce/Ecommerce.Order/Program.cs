﻿using System;
using System.Threading.Tasks;
using NServiceBus;

namespace Ecommerce.Order
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "Order";

            var endpointConfiguration = new EndpointConfiguration("Order");

            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop();
        }
    }
}
