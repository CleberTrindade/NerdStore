using System.Threading.Tasks;

namespace NS.Core.Data
{
	public interface IUnitOfWork
	{
		Task<bool> Commit();
	}
}
