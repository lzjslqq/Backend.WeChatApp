using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Repository.Core
{
	public class DbSession : IDbSession
	{
		private IDbConnection _dbconnection;
		private IDbTransaction _transaction;
		public IDbConnection Connection
		{
			get { return _dbconnection ?? ConnectionFactory.CreateSqlConnection(); }
			set { _dbconnection = value; }
		}

		public IDbTransaction Transaction
		{
			get { return _transaction; }
		}

		public IDbTransaction Begin(IsolationLevel isolation = IsolationLevel.ReadCommitted)
		{
			return _dbconnection.BeginTransaction(isolation);
		}

		public void Commit()
		{
			_transaction.Commit();
		}

		public void Rollback()
		{
			_transaction.Rollback();
		}

		public void Dispose()
		{
			if (_dbconnection.State != ConnectionState.Closed)
			{
				_dbconnection.Close();
			}
		}
	}
}