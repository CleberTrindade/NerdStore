using Microsoft.AspNetCore.Mvc;
using NS.Clientes.API.Application.Commands;
using NS.Core.Mediator;
using NS.WepApi.Core.Controllers;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NS.Clientes.API.Controllers
{
	public class ClientesController : MainController
	{
		private readonly IMediatorHandler _mediatorHandler;

		public ClientesController(IMediatorHandler mediatorHandler)
		{
			_mediatorHandler = mediatorHandler;
		}

		[HttpGet("clientes")]
		public async Task<IActionResult> Index()
		{
			var resultado = await _mediatorHandler.EnviarComando(
				new RegistrarClienteCommand(Guid.NewGuid(), "Cleber Trindade", "cleber@cleber.com", "94397734305"));			

			return CustomResponse(resultado);
		}
	}
}
