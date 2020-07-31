using Microsoft.Extensions.DependencyInjection;
using NS.Catalogo.API.Data;
using NS.Catalogo.API.Data.Repository;
using NS.Catalogo.API.Models;

namespace NS.Catalogo.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IProdutoRepository, ProdutoRepository>();
			services.AddScoped<CatalogoContext>();
		}
	}
}
