using System;
using System.Threading.Tasks;
using Ecommerce.Commands.Order;
using NServiceBus;
using NServiceBus.Logging;

namespace Ecommerce.Application
{
    class Program
    {
        static ILog log = LogManager.GetLogger<Program>();

        static async Task Main(string[] args)
        {
            Console.Title = "ApplicationUI";

            var endpointConfiguration = new EndpointConfiguration("ApplicationUI");

            //LearningTransport --> used for leaning, do not require infrastructure and should not be used in Production
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            var routing = transport.Routing();
           
            routing.RouteToEndpoint(typeof(InitiateOrder), "Order");

            var endpointInstance = await Endpoint.Start(endpointConfiguration);
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            // Replace with:
            await RunLoop(endpointInstance);

            await endpointInstance.Stop();
        }

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                log.Info("Press 'P' to place an order, or 'Q' to quit.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        // Instantiate the command
                        var command = new InitiateOrder
                        {
                            TransactionId = Guid.NewGuid(),
                            OrderId = "0001"
                        };

                        // Send the command to the local endpoint
                        log.Info($"Sending InitiateOrder command, TransactionId = {command.TransactionId} and OrderId = {command.OrderId}");
                        await endpointInstance.Send(command);

                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        log.Info("Unknown input. Please try again.");
                        break;
                }
            }
        }
    }
}
