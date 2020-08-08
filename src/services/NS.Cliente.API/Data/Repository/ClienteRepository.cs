using Microsoft.EntityFrameworkCore;
using NS.Clientes.API.Data;
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
		public async Task<Cliente> ObterPorCpf(string cpf)
		{
			return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
		}
		
		public void Adicionar(Cliente cliente)
		{
			_context.Clientes.Add(cliente);
		}

		public void Atualizar(Cliente cliente)
		{
			_context.Clientes.Update(cliente);
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
