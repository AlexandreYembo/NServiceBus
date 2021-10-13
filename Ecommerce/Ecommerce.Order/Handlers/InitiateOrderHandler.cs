using Ecommerce.Commands.Order;
using NServiceBus;
using System.Threading.Tasks;
using NServiceBus.Logging;

namespace Ecommerce.Order.Handlers
{
    public class InitiateOrderHandler : IHandleMessages<InitiateOrder>
    {
        static ILog log = LogManager.GetLogger<InitiateOrderHandler>();
        public Task Handle(InitiateOrder message, IMessageHandlerContext context)
        {
            log.Info($"Order initiate, TransactionId = {message.TransactionId}, OrderId = {message.OrderId}");
            return Task.CompletedTask;
        }
    }
}
