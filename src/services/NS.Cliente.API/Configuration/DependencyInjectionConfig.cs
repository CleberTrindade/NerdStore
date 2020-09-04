using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NS.Catalogo.API.Data.Repository;
using NS.Clientes.API.Application.Commands;
using NS.Clientes.API.Application.Events;
using NS.Clientes.API.Data;
using NS.Clientes.API.Models;
using NS.Clientes.API.Services;
using NS.Core.Mediator;

namespace NS.Clientes.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IMediatorHandler, MediatorHandler>();
			services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

			services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

			services.AddScoped<IClienteRepository, ClienteRepository>();
			services.AddScoped<ClientesContext>();

			
		}
	}
}
