using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace ExemploDapperMySql.Infra
{
	public class DataContext
	{
		public IDbConnection AbrirConexao()
		{
			var connectionString = "server=127.0.0.1;port=3306;database=exemplo_entity_framawork;user=root;password=123456";
			//var connectionString = $"Server=127.0.0.1; Database=exemplo_entity_framawork; Uid={_dbSettings.UserId}; Pwd={_dbSettings.Password};";

			IDbConnection dbConnection = new MySqlConnection(connectionString);

			DefaultTypeMap.MatchNamesWithUnderscores = true;

			dbConnection.Open();

			return dbConnection;
		}
	}
}
