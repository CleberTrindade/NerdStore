using FluentValidation.Results;
using NS.Core.Data;
using System.Threading.Tasks;

namespace NS.Core.Messages
{
	public abstract class CommandHandler
	{
		protected ValidationResult ValidationResult;

		protected CommandHandler()
		{
			ValidationResult = new ValidationResult();
		}

		protected void AdicionarErrro(string mensagem)
		{
			ValidationResult.Errors.Add( new ValidationFailure(string.Empty, mensagem) );
		}

		protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
		{
			if (await uow.Commit()) AdicionarErrro("Houve um erro ao persistir os dados.");

			return ValidationResult;
		}
	}
}
