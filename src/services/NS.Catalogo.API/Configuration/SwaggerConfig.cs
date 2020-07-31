using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace NS.Catalogo.API.Configuration
{
	public static class SwaggerConfig
	{
		public static void AddSwaggerConiguration(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo()
				{
					Title = "NerdStore Catálogo API",
					Description = "Esta API faz parte do Sistema Distribuido NerdStore.",
					Contact = new OpenApiContact() { Name = "Cleber Trindade", Email = "cleber.trindade.net@gmail.com" },
					License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
				});
			});
		}

		public static void UseSwaggerConfiguration(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
			});
		}
	}
}
