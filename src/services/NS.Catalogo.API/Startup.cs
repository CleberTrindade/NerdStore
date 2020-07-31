using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NS.Catalogo.API.Configuration;
using NS.Catalogo.API.Data;
using NS.Catalogo.API.Data.Repository;
using NS.Catalogo.API.Models;

namespace NS.Catalogo.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IHostEnvironment hostEnvironment)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(hostEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
				.AddEnvironmentVariables();

			if (hostEnvironment.IsDevelopment()) {
				builder.AddUserSecrets<Startup>();
			}
			Configuration = builder.Build();
		}		

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddApiConiguration(Configuration);

			services.AddSwaggerConiguration();

			services.RegisterServices();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseApiConfiguration(env);

			app.UseSwaggerConfiguration();
		}
	}
}
