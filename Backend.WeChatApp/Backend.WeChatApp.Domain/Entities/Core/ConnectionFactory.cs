using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Backend.WeChatApp.Domain.Entities.Core
{
	public static class ConnectionFactory
	{
		public static IDbConnection CreateConnection<T>() where T : IDbConnection, new()
		{
			var connection = new T();
			connection.ConnectionString = ConfigurationManager.ConnectionStrings["WriteConnString"].ConnectionString;
			connection.Open();
			return connection;
		}

		public static IDbConnection CreateSqlConnection()
		{
			return CreateConnection<SqlConnection>();
		}
	}
}