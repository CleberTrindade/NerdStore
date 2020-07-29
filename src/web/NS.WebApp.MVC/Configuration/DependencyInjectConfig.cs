using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NS.WebApp.MVC.Extensions;
using NS.WebApp.MVC.Services;
using NS.WebApp.MVC.Services.Autenticacao;

namespace NS.WebApp.MVC.Configuration
{
	public static class DependencyInjectConfig
	{
		public static void DependencyInjectResolve(this IServiceCollection services)
		{			
			services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IUser, AspNetUser>();
		}
	}
}
