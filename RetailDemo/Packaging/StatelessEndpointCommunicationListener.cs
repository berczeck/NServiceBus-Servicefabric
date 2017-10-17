using Microsoft.ServiceFabric.Services.Communication.Runtime;
using NServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Packaging
{
    public class StatelessEndpointCommunicationListener : ICommunicationListener
    {
        private IEndpointInstance endpointInstance;

        public async Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            var endpointName = "Packaging";

            var endpointConfiguration = new EndpointConfiguration(endpointName);
            
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString("host=localhost;username=guest;password=guest");

            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.EnableInstallers();

            // endpoint configuration
            endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            return endpointName;
        }

        public Task CloseAsync(CancellationToken cancellationToken)
        {
            return endpointInstance.Stop();
        }

        public void Abort()
        {
            CloseAsync(CancellationToken.None);
        }
    }
}
