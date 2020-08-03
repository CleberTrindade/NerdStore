using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NS.WepApi.Core.Autenticacao;

namespace NS.Autenticacao.API.Configuration
{
	public static class ApiConfig
	{
		public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
		{
			services.AddControllers();			

			return services;
		}

		public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(x => x.AllowAnyOrigin()
							  .AllowAnyMethod()
							  .AllowAnyHeader());

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthConfiguration();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			return app;
		}
	}
}
