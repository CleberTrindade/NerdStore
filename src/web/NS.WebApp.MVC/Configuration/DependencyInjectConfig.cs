﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NS.WebApp.MVC.Extensions;
using NS.WebApp.MVC.Services;
using NS.WebApp.MVC.Services.Autenticacao;
using NS.WebApp.MVC.Services.Catalogo;
using NS.WebApp.MVC.Services.Handlers;
using NS.WepApi.Core.Usuario;
using Polly;
using System;

namespace NS.WebApp.MVC.Configuration
{
	public static class DependencyInjectConfig
	{
		public static void DependencyInjectResolve(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();

			services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

			services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

			services.AddHttpClient<ICatalogoService, CatalogoService>()
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				.AddTransientHttpErrorPolicy(
					p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(600))
				);

			//services.AddHttpClient("Refit", options =>
			//{
			//	options.BaseAddress = new Uri(configuration.GetSection("CatalogoUrl").Value);
			//})
			//.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
			//.AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);



			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();
		}
	}
}
