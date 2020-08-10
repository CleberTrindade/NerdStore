using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NS.Catalogo.API.Models;
using NS.WepApi.Core.Autenticacao;
using NS.WepApi.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NS.Catalogo.API.Controllers
{

	[Authorize]
	public class CatalogoController : MainController
	{
		private readonly IProdutoRepository _produtoRepository;
		public CatalogoController(IProdutoRepository produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		[AllowAnonymous]
		[HttpGet("catalogo/produtos")]
		public async Task<IEnumerable<Produto>> Index() {
			return await _produtoRepository.ObterTodos();
		}

		[ClaimsAuthorize("Catalogo", "Ler")]
		[HttpGet("catalogo/produtos/{id}")]
		public async Task<Produto> ProdutoDetalhe(Guid id)
		{
			return await _produtoRepository.ObterPorId(id);
		}
	}
}
