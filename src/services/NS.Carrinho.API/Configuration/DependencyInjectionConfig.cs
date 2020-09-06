using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NS.Carrinho.API.Data;
using NS.WepApi.Core.Usuario;

namespace NS.Carrinho.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();
			services.AddScoped<CarrinhoContext>();
		}
	}
}
