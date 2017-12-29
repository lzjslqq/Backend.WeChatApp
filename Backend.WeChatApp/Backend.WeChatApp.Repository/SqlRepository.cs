using Backend.WeChatApp.Domain.Entities.Core;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Backend.WeChatApp.Repository
{
	public class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
	{
		private readonly IDbConnection _connection;
		private readonly IDbTransaction _transaction;

		public SqlRepository(IDbConnection connection, IDbTransaction transaction = null)
		{
			_connection = connection;
			_transaction = transaction;
		}

		public IEnumerable<TEntity> GetList()
		{
			throw new NotImplementedException();
		}

		public TEntity Get(Guid id)
		{
			using (_connection)
			{
				return _connection.Get<TEntity>(id);
			}
		}

		public bool Update(TEntity t)
		{
			throw new NotImplementedException();
		}

		public TEntity Insert(TEntity apply)
		{
			throw new NotImplementedException();
		}

		public bool Delete(TEntity t)
		{
			throw new NotImplementedException();
		}
	}
}