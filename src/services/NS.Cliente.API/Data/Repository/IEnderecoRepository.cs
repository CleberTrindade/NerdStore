using NS.Clientes.API.Models;
using NS.Core.Datas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NS.Clientes.API.Repository
{
	public interface IEnderecoRepository : IRepository<Endereco>
	{
		Task<IEnumerable<Endereco>> ObterTodos();
		Task<Endereco> ObterPorId(Guid id);

		void Adicionar(Endereco endereco);
		void Atualizar(Endereco endereco);

	}
}
