using NS.Core.Messages;
using System;

namespace NS.Clientes.API.Application.Events
{
	public class ClienteRegistradoEvent : Event
	{
		public Guid Id { get; set; }
		public string Nome { get; private set; }
		public string Email { get; private set; }
		public string Cpf { get; private set; }

		public ClienteRegistradoEvent(Guid id, string nome, string email, string cpf)
		{
			AggregateId = id;
			Id = id;
			Nome = nome;
			Email = email;
			Cpf = cpf;
		}
	}
}
