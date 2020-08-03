using Microsoft.Extensions.Options;
using NS.WebApp.MVC.Extensions;
using NS.WebApp.MVC.Models.Produto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Services.Catalogo
{
	public class CatalogoService : Service, ICatalogoService
	{
		private readonly HttpClient _httpClient;

		public CatalogoService(HttpClient httpClient, IOptions<AppSettings> settings)
		{
			httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
			_httpClient = httpClient;
		}
		public async Task<ProdutoViewModel> ObterPorId(Guid id)
		{
			var response = await _httpClient.GetAsync($"/catalogo/produtos/{id}");

			TratarErrosResponse(response);

			return await DeserializarObjectResponse<ProdutoViewModel>(response);

		}

		public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
		{
			var response = await _httpClient.GetAsync("/catalogo/produtos/");

			TratarErrosResponse(response);

			return await DeserializarObjectResponse<IEnumerable<ProdutoViewModel>>(response);
		}
	}
}