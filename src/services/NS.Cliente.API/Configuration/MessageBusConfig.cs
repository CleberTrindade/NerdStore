using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NS.Clientes.API.Services;
using NS.Core.Utils;
using NS.MessageBus;

namespace NS.Clientes.API.Configuration
{
	public static class MessageBusConfig
	{
		public static void AddMessageBusConfiguration(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
				.AddHostedService<RegistroClienteIntegrationHandler>();
		}
	}
}
