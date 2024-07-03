using ExemploDapperMySql.Application.Services;
using ExemploDapperMySql.Domain.Contracts.Services;

namespace ExemploDapperMySql.DependencyInjections
{
	public static class ServiceDependency
	{
		public static void AddClientDIServices(this IServiceCollection services)
		{
			services.AddTransient<IClienteService, ClienteService>();
		}
	}
}
