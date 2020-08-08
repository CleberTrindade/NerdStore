using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace NS.Clientes.API.Application.Events
{
	public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>
	{
		public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
		{
			//Enviar evento de confirmação
			return Task.CompletedTask;
		}
	}
}
