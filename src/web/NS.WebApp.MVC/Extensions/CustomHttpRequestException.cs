using System;
using System.Net;

namespace NS.WebApp.MVC.Extensions
{
	public class CustomHttpRequestException : Exception
	{
		public HttpStatusCode StatusCode;

		public CustomHttpRequestException() { }

		public CustomHttpRequestException(string message, Exception innerExcepion) : base(message, innerExcepion) { }

		public CustomHttpRequestException(HttpStatusCode statusCode) {
			StatusCode = statusCode;
		}
	}
}
