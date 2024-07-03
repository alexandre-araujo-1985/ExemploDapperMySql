using ExemploDapperMySql.Domain.Entities;

namespace ExemploDapperMySql.Requests
{
	public class ClienteRequest
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		public DateTime DataCadastro { get; set; }

		public static Cliente ConvertToCliente(ClienteRequest clienteRequest)
		{
			return new Cliente
			{
				Id = clienteRequest.Id,
				Nome = clienteRequest.Nome,
				DataCadastro = clienteRequest.DataCadastro
			};
		}
	}
}
