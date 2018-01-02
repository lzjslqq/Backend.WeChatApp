using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Repository.Core
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