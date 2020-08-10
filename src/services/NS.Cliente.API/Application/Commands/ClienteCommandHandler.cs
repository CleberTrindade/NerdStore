using FluentValidation.Results;
using MediatR;
using NS.Clientes.API.Application.Events;
using NS.Clientes.API.Models;
using NS.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NS.Clientes.API.Application.Commands
{
	public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteCommandHandler(IClienteRepository clienteRepository)
		{
			_clienteRepository = clienteRepository;
		}

		public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid()) return message.ValidationResult;

			var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

			var clienteExistente = await _clienteRepository.ObterPorCpf(cliente.Cpf.Numero);

			if (clienteExistente == null)
			{
				//Coloquei para não estava aceitando " clienteExistente != null ".
				//A Api estava parando sem retornar erro.
			}
			else
			{
				AdicionarErrro("Este CPF já está em uso.");
				return ValidationResult;
			}

			_clienteRepository.Adicionar(cliente);

			cliente.AdicionarEvento(new ClienteRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf));

			return await PersistirDados(_clienteRepository.UnitOfWork);
		}
	}
}
