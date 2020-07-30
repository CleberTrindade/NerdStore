using NS.WebApp.MVC.Extensions;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Services
{
	public abstract class Service
	{
		protected bool TratarErrosResponse(HttpResponseMessage response)
		{
			switch ((int)response.StatusCode)
			{
				case 401:
				case 403:
				case 404:
				case 500:
					throw new CustomHttpRequestException(response.StatusCode);

				case 400:
					return false;
			}
			response.EnsureSuccessStatusCode();
			return true;
		}

		protected StringContent ObterConteudo(object dado)
		{
			return new StringContent(
					JsonSerializer.Serialize(dado),
					Encoding.UTF8,
					"application/json");
		}
		protected async Task<T> DeserializarObjectResponse<T>(HttpResponseMessage responseMessage)
		{
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
		}
	}
}
