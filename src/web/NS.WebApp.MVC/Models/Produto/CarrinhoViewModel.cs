using System.Collections.Generic;

namespace NS.WebApp.MVC.Models.Produto
{
	public class CarrinhoViewModel
	{
		public decimal ValorTotal { get; set; }
		public List<ItemProdutoViewModel> Itens { get; set; } = new List<ItemProdutoViewModel>();
	}
}
