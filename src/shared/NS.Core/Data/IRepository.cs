using NS.Core.Data;
using NS.Core.DomainObjects;
using System;

namespace NS.Core.Datas
{
	public interface IRepository<T> : IDisposable where T : IAggregateRoot
	{
		IUnitOfWork UnitOfWork { get; }
	}
}