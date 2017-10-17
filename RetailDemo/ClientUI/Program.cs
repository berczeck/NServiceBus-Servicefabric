using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace ClientUI
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static ILog log = LogManager.GetLogger<Program>();

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

                        for (int i = 0; i < 20; i++)
                        {
                            // Instantiate the command
                            var command = new PlaceOrder
                            {
                                OrderId = Guid.NewGuid().ToString()
                            };

                            // Send the command to the local endpoint
                            log.Info($"Sending PlaceOrder command, OrderId = {command.OrderId}");
                            await endpointInstance.Send(command)
                                .ConfigureAwait(false);
                        }

                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        log.Info("Unknown input. Please try again.");
                        break;
                }
            }
        }

        static async Task AsyncMain()
        {
            Console.Title = "ClientUI";

            var endpointConfiguration = new EndpointConfiguration("ClientUI");

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            //transport.ConnectionString("host=localhost;username=guest;password=guest");
            transport.ConnectionString("host=wasp.rmq.cloudamqp.com;username=vhsciryg;password=zm-NXMl9cMVNUZSIFNPCBPXyoup8WE1V;virtualhost=vhsciryg;");

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.EnableInstallers();

            var endpointInstance = 
                await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            await RunLoop(endpointInstance).ConfigureAwait(false);
        }
    }
}
