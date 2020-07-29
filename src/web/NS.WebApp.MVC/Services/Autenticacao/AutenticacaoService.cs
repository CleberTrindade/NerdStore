using NS.WebApp.MVC.Models;
using NS.WebApp.MVC.Models.Usuario;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Services.Autenticacao
{
	public class AutenticacaoService : Service, IAutenticacaoService
	{
		private readonly HttpClient _httpClient;
		public AutenticacaoService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLogin)
		{
			var loginContent = new StringContent(
				JsonSerializer.Serialize(usuarioLogin),
				Encoding.UTF8,
				"application/json");

			var response = await _httpClient.PostAsync("https://localhost:44394/api/autenticacao/autenticar", loginContent);

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			if (!TratarErrosResponse(response))
			{
				return new UsuarioRespostaLoginViewModel
				{
					ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
				};				
			}

			return JsonSerializer.Deserialize<UsuarioRespostaLoginViewModel>(await response.Content.ReadAsStringAsync(), options);
		}

		public async Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistro)
		{
			var registroContent = new StringContent(
				JsonSerializer.Serialize(usuarioRegistro),
				Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("https://localhost:44394/api/autenticacao/nova-conta", registroContent);

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			if (!TratarErrosResponse(response))
			{
				return new UsuarioRespostaLoginViewModel
				{
					ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
				};
			}

			return JsonSerializer.Deserialize<UsuarioRespostaLoginViewModel>(await response.Content.ReadAsStringAsync(), options);
		}
	}
}