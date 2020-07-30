using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using NS.WebApp.MVC.Extensions;
using NS.WebApp.MVC.Models;
using NS.WebApp.MVC.Models.Usuario;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Services.Autenticacao
{
	public class AutenticacaoService : Service, IAutenticacaoService
	{
		private readonly HttpClient _httpClient;		

		public AutenticacaoService(HttpClient httpClient, IOptions<AppSettings> settings)
		{
			httpClient.BaseAddress = new Uri(settings.Value.AutenticacaoUrl);
			_httpClient = httpClient;			
		}

		public async Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLogin)
		{
			var loginContent = ObterConteudo(usuarioLogin);

			var response = await _httpClient.PostAsync("/api/autenticacao/autenticar", loginContent);

			if (!TratarErrosResponse(response))
			{
				return new UsuarioRespostaLoginViewModel
				{
					ResponseResult = await DeserializarObjectResponse<ResponseResult>(response)
				};				
			}
			return await DeserializarObjectResponse<UsuarioRespostaLoginViewModel>(response);
		}

		public async Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistro)
		{
			var registroContent = ObterConteudo(usuarioRegistro);

			var response = await _httpClient.PostAsync("/api/autenticacao/nova-conta", registroContent);

			if (!TratarErrosResponse(response))
			{
				return new UsuarioRespostaLoginViewModel
				{
					ResponseResult = await DeserializarObjectResponse<ResponseResult>(response)
				};
			}
			return await DeserializarObjectResponse<UsuarioRespostaLoginViewModel>(response);
		}
	}
}