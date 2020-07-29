using NS.WebApp.MVC.Models.Usuario;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Services
{
	public interface IAutenticacaoService
	{
		Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLogin);

		Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistro);
	}

	
}
