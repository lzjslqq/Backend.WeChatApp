using Backend.WeChatApp.Entity;
using System;
using System.Collections.Generic;

namespace Backend.WeChatApp.Repository.Sql
{
	public interface ISqlRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
	{
		int Execute(string sql, object param = null, int? commandTimeout = null, System.Data.CommandType? commandType = null);

		IEnumerable<TEntity> GetList(object predicate = null, IList<DapperExtensions.ISort> sort = null);

		IEnumerable<TEntity> GetPageList(object predicate, IList<DapperExtensions.ISort> sort, int page, int pageSize);
	}
}