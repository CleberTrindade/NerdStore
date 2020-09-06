using Microsoft.AspNetCore.Mvc;
using NS.WebApp.MVC.Models.Produto;
using System;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Controllers
{
	public class CarrinhoController : MainController
	{
		[Route("carrinho")]
		public async Task<IActionResult> index()
		{
			return View();
		}

		[HttpPost]
		[Route("carrinho/adicionar-item")]
		public async Task<IActionResult> AdicionarItemCarrinho(ItemProdutoViewModel itemProduto)
		{
			return RedirectToAction("Index");
		}

		[HttpPost]
		[Route("carrinho/atualizar-item")]
		public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
		{
			return RedirectToAction("Index");
		}

		[HttpPost]
		[Route("carrinho/remover-item")]
		public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
		{
			return RedirectToAction("Index");
		}
	}
}
