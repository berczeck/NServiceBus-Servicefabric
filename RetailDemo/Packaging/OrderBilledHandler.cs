using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Packaging
{
    public class OrderBilledHandler :
    IHandleMessages<OrderBilled>
    {
        static ILog log = LogManager.GetLogger<OrderBilledHandler>();

        public Task Handle(OrderBilled message, IMessageHandlerContext context)
        {
            log.Info($":::::::Received OrderBilled, OrderId = {message.OrderId} - Order packaged...");

            return Task.CompletedTask;
        }
    }
}
