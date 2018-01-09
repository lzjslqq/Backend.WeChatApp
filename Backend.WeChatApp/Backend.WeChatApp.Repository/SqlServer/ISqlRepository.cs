using Backend.WeChatApp.Entity;
using System;
using System.Collections.Generic;
using DapperExtensions;
using System.Data;
using Backend.WeChatApp.Repository.Core;

namespace Backend.WeChatApp.Repository.SqlServer
{
	public interface ISqlRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
	{
		IDbSession Dbsession { get; }

		int Execute(string sql, object param = null, CommandType? commandType = null);

		IEnumerable<TEntity> GetList(object predicate = null, IList<ISort> sort = null, bool buffered = false);

		IEnumerable<TEntity> GetPageList(object predicate, IList<ISort> sort, int page, int pageSize);
	}
}