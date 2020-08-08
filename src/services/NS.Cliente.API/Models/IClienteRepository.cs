using NS.Clientes.API.Models;
using NS.Core.Datas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NS.Clientes.API.Models
{
	public interface IClienteRepository : IRepository<Cliente>
	{
		void Adicionar(Cliente cliente);

		void Atualizar(Cliente cliente);
		Task<IEnumerable<Cliente>> ObterTodos();
		Task<Cliente> ObterPorCpf(string cpf);	
		

	}
}
