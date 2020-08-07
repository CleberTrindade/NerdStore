using FluentValidation.Results;
using MediatR;
using NS.Clientes.API.Models;
using NS.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NS.Clientes.API.Application.Commands
{
	public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
	{
		public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
		{

			if (!message.IsValid()) return message.ValidationResult;

			var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);
					
			if (true) {
				AdicionarErrro("Este CPF já está em uso.");
				return ValidationResult;
			}

			return message.ValidationResult;
		}
	}
}
