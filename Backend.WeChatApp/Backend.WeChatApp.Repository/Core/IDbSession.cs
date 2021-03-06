﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Repository.Core
{
	public interface IDbSession : IDisposable
	{
		IDbConnection Connection { get; set; }
		IDbTransaction Transaction { get; }
		int? CommandTimeout { get; set; }

		IDbTransaction BeginTran(IsolationLevel isolation = IsolationLevel.ReadCommitted);

		void Commit();

		void Rollback();
	}
}