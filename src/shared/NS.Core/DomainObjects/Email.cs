using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace NS.Core.DomainObjects
{
	public class Email
	{
		public const int EmailMaxLength = 254;
		public const int EmailMinLength = 5;
		public string Endereco { get; private set; }
		public Email() { }
		public Email(string endereco)
		{ 
			Endereco = endereco;
		}
		public static bool Validar(string email)
		{ 
			var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\d{1,3}\.{3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
			return regexEmail.IsMatch(email);
			//07:02
		}
	}
}
