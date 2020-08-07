﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NS.Clientes.API.Data;
using NS.WepApi.Core.Autenticacao;

namespace NS.Clientes.API.Configuration
{
	public static class ApiConfig
	{
		public static void AddApiConiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ClientesContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddControllers();

			services.AddCors(options =>
			{
				options.AddPolicy("Total", builder =>
						builder
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader());
			});
		}

		public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors("Total");

			app.UseAuthConfiguration();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
