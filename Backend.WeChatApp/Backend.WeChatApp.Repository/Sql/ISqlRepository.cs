using Backend.WeChatApp.Entity;
using System;
using System.Collections.Generic;
using DapperExtensions;
using System.Data;

namespace Backend.WeChatApp.Repository.Sql
{
	public interface ISqlRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
	{
		int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

		IEnumerable<TEntity> GetList(object predicate = null, IList<ISort> sort = null);

		IEnumerable<TEntity> GetPageList(object predicate, IList<ISort> sort, int page, int pageSize);
	}
}