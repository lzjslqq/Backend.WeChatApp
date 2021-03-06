﻿using System;
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
		private int? commandTimeout;

		public virtual int? CommandTimeout
		{
			get { return commandTimeout; }
			set { commandTimeout = value; }
		}

		public virtual IDbConnection Connection
		{
			get { return _dbconnection ?? ConnectionFactory.CreateSqlConnection(); }
			set { _dbconnection = value; }
		}

		public IDbTransaction Transaction
		{
			get { return _transaction; }
		}

		public IDbTransaction BeginTran(IsolationLevel isolation = IsolationLevel.ReadCommitted)
		{
			_transaction = _dbconnection.BeginTransaction(isolation);
			return _transaction;
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
			if (_dbconnection != null)
			{
				_dbconnection.Close();
				_transaction.Dispose();
				_dbconnection.Dispose();
			}
		}
	}
}