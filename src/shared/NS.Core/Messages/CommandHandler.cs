using FluentValidation.Results;

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
	}
}
