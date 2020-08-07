using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NS.Clientes.API.Application.Commands;
using NS.Core.Mediator;

namespace NS.Clientes.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IMediatorHandler, MediatorHandler>();
			services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
		}
	}
}
