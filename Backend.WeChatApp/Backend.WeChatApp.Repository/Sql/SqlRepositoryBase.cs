using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Repository.Core;
using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Backend.WeChatApp.Repository.Sql
{
	public class SqlRepositoryBase<TEntity> : ISqlRepository<TEntity> where TEntity : EntityBase, new()
	{
		protected IDbSession Dbsession { get; private set; }

		public SqlRepositoryBase(IDbSession dbsession)
		{
			Dbsession = dbsession;
		}

		public virtual IEnumerable<TEntity> GetList(object predicate = null, IList<ISort> sort = null)
		{
			return Dbsession.Connection.GetList<TEntity>(predicate, sort, Dbsession.Transaction);
		}

		public virtual TEntity Get(Guid id)
		{
			return Dbsession.Connection.Get<TEntity>(id, Dbsession.Transaction);
		}

		public virtual bool Update(TEntity entity)
		{
			return Dbsession.Connection.Update(entity, Dbsession.Transaction);
		}

		public virtual TEntity Insert(TEntity apply)
		{
			return Dbsession.Connection.Insert(apply, Dbsession.Transaction);
		}

		public virtual bool Delete(TEntity t)
		{
			return Dbsession.Connection.Delete(t, Dbsession.Transaction);
		}

		public virtual IEnumerable<TEntity> GetPageList(object predicate, IList<ISort> sort, int page, int pageSize)
		{
			return Dbsession.Connection.GetPage<TEntity>(predicate, sort, page, pageSize, Dbsession.Transaction);
		}

		/// <summary>
		/// 执行sql语句操作
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <returns></returns>
		public virtual int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return Dbsession.Connection.Execute(sql, param, Dbsession.Transaction, commandTimeout, commandType);
		}
	}
}