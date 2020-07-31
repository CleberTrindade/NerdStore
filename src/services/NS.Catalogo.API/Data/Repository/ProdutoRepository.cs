using Microsoft.EntityFrameworkCore;
using NS.Catalogo.API.Models;
using NS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS.Catalogo.API.Data.Repository
{
	public class ProdutoRepository : IProdutoRepository
	{
		private readonly CatalogoContext _context;

		public ProdutoRepository(CatalogoContext context)
		{
			_context = context;
		}

		public IUnitOfWork UnitOfWork => _context;

		public async Task<IEnumerable<Produto>> ObterTodos()
		{
			return await _context.Produtos.AsNoTracking().ToListAsync();
		}
		public async Task<Produto> ObterPorId(Guid id)
		{
			return await _context.Produtos.FindAsync(id);
		}
		
		public async void Adicionar(Produto produto)
		{
			_context.Produtos.Add(produto);
		}

		public async void Atualizar(Produto produto)
		{
			_context.Produtos.Update(produto);
		}

		public void Dispose()
		{
			_context?.Dispose();
		}
	}
}
