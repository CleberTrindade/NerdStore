using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NS.WebApp.MVC.Models;

namespace NS.WebApp.MVC.Controllers
{
	public class HomeController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[Route("erro/{id:length(3,3)}")]
		public IActionResult Error(int id)
		{
			var modelErro = new ErrorViewModel();

			switch (id)
			{
				case 500:
					modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
					modelErro.Titulo = "Ocorreu um erro!";
					modelErro.ErroCode = id;
					break;
				case 404:
					modelErro.Mensagem = "A página que está procurando não existe! <br /> Em caso de dúvidas, entre em contato com o nosso suporte.";
					modelErro.Titulo = "Ops! Página não encontrada.";
					modelErro.ErroCode = id;
					break;
				case 403:
					modelErro.Mensagem = "Você não tem permissão para fazer isto.";
					modelErro.Titulo = "Acesso negado.";
					modelErro.ErroCode = id;
					break;
				default:
					StatusCode(404);
					break;
			}

			return View("Error", modelErro);
		}

	}
}
