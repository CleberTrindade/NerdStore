using FluentValidation.Results;
using NS.Core.Messages;
using System.Threading.Tasks;

namespace NS.Core.Mediator
{
	public interface IMediatorHandler
	{
		Task PublicarEvento<T>(T evento) where T : Event;
		Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
	}
}
