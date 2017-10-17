using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
    class Program
    {
        static void Main()
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            Console.Title = "Sales";

            var endpointConfiguration = new EndpointConfiguration("Sales");

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            //transport.ConnectionString("host=localhost;username=guest;password=guest");
            transport.ConnectionString("host=wasp.rmq.cloudamqp.com;username=vhsciryg;password=zm-NXMl9cMVNUZSIFNPCBPXyoup8WE1V;virtualhost=vhsciryg;");

            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.EnableInstallers();

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
