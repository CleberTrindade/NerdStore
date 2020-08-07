using Microsoft.EntityFrameworkCore;
using NS.Clientes.API.Data;
using NS.Clientes.API.Data.Repository;
using NS.Clientes.API.Models;
using NS.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NS.Catalogo.API.Data.Repository
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly ClientesContext _context;

		public ClienteRepository(ClientesContext context)
		{
			_context = context;
		}

		public IUnitOfWork UnitOfWork => _context;

		public async Task<IEnumerable<Cliente>> ObterTodos()
		{
			return await _context.Clientes.AsNoTracking().ToListAsync();
		}
		public async Task<Cliente> ObterPorId(Guid id)
		{
			return await _context.Clientes.FindAsync(id);
		}
		
		public async void Adicionar(Cliente produto)
		{
			_context.Clientes.Add(produto);
		}

		public async void Atualizar(Cliente produto)
		{
			_context.Clientes.Update(produto);
		}

		public void Dispose()
		{
			_context?.Dispose();
		}
	}
}
