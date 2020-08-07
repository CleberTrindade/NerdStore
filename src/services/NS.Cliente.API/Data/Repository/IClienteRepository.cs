using NS.Clientes.API.Models;
using NS.Core.Datas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NS.Clientes.API.Data.Repository
{
	public interface IClienteRepository : IRepository<Cliente>
	{
		Task<IEnumerable<Cliente>> ObterTodos();
		Task<Cliente> ObterPorId(Guid id);

		void Adicionar(Cliente cliente);
		void Atualizar(Cliente cliente);

	}
}
