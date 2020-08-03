using NS.WebApp.MVC.Models.Produto;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NS.WebApp.MVC.Services.Catalogo
{
	public interface ICatalogoService
	{
		Task<IEnumerable<ProdutoViewModel>> ObterTodos();
		Task<ProdutoViewModel> ObterPorId(Guid id);
	}

	public interface ICatalogoServiceRefit
	{ 
		[Get("/catalogo/produtos/")]
		Task<IEnumerable<ProdutoViewModel>> ObterTodos();

		[Get("/catalogo/produtos/{id}")]
		Task<ProdutoViewModel> ObterPorId(Guid id);
	}
}
