using Dapper;
using ExemploDapperMySql.Domain.Contracts.Repositories;

namespace ExemploDapperMySql.Infra.Repositories
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected readonly DataContext _dataContext;
		private readonly string _tabela;

		public RepositoryBase(DataContext dataContext, string tabela)
		{
			_dataContext = dataContext;
			_tabela = tabela;
		}
		public T Pesquisar(int id)
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = $"select * from {_tabela} where id = @id;";

			var parametros = new Dictionary<string, dynamic> { { "id", id } };

			return conexao.Query<T>(sql, new DynamicParameters(parametros)).Single();
		}

		public IEnumerable<T> ListarTodos()
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = $"select * from {_tabela};";

			return conexao.Query<T>(sql);
		}
		public int Incluir(Dictionary<string, dynamic> obj)
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = @$"insert into {_tabela} 
						 values(";

			foreach (var item in obj)
			{
				if (obj.Last().Equals(item))
				{
					sql += string.Concat($"@{item.Key});");
					continue;
				}

				sql += string.Concat($"@{item.Key},");
			}

			sql += string.Concat($"SELECT LAST_INSERT_ID();");

			return conexao.ExecuteScalar<int>(sql, new DynamicParameters(obj));
		}

		public void Alterar(int id, Dictionary<string, dynamic> obj)
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = @$"update {_tabela} 
						 set ";

			if (obj.Keys.Count == 1)
			{
				var item = obj.First();

				sql += string.Concat($"{item.Key} = @{item.Key}");
				sql += string.Concat("where id = @id;");

				conexao.ExecuteReader(sql, obj);
			}

			foreach (var item in obj)
			{
				if (obj.Last().Equals(item))
				{
					sql += string.Concat($"{item.Key} = @{item.Key} ");
					continue;
				}
				sql += string.Concat($"{item.Key} = @{item.Key}, ");
			}

			sql += string.Concat("where id = @id;");

			obj.Add("id", id);

			conexao.ExecuteReader(sql, new DynamicParameters(obj));
		}

		public void Excluir(int id)
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = $"delete from {_tabela} where id = @id;";
			var parametros = new Dictionary<string, dynamic> { { "id", id } };

			conexao.Execute(sql, new DynamicParameters(parametros));
		}
	}
}
