using ExemploDapperMySql.Domain.Entities;
using ExemploDapperMySql.Domain.Constants;
using ExemploDapperMySql.Domain.Contracts.Repositories;

namespace ExemploDapperMySql.Infra.Repositories
{
	public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
	{
		public ClienteRepository(DataContext dataContext) : base(dataContext, TabelaConstant.TabelaCliente)
		{
		}
	}
}
