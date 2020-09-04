using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NS.Core.Utils;
using NS.MessageBus;

namespace NS.Autenticacao.API.Configuration
{
	public static class MessageBusConfig
	{
		public static void AddMessageBusConfiguration(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
		}
	}
}
