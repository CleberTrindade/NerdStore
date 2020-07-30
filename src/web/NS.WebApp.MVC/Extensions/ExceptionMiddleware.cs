﻿using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Extensions
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (CustomHttpRequestException ex)
			{
				HandleRequestExceptionAsync(httpContext, ex);
				throw;
			}
		}

		private static void HandleRequestExceptionAsync(HttpContext context, CustomHttpRequestException httpRequestException)
		{
			if (httpRequestException.StatusCode == HttpStatusCode.Unauthorized)
			{
				context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
				return;
			}
			context.Response.StatusCode = (int)httpRequestException.StatusCode;
		}
	}	
}
