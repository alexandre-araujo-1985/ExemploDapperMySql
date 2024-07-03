using ExemploDapperMySql.Domain.Contracts.Repositories;
using ExemploDapperMySql.Infra;
using ExemploDapperMySql.Infra.Repositories;

namespace ExemploDapperMySql.DependencyInjections
{
	public static class RepositoryDependency
	{
		public static void AddClientDIRepository(this IServiceCollection services)
		{
			services.AddTransient<IClienteRepository, ClienteRepository>();
			services.AddSingleton<DataContext>();
		}
	}
}
