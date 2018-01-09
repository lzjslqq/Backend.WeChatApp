using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Repository.Core;
using Backend.WeChatApp.Repository;
using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using DapperExtensions.Mapper;
using Backend.WeChatApp.Repository.DapperExtensionCore;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Repository.SqlServer
{
	public class SqlRepositoryBase<TEntity> : ISqlRepository<TEntity> where TEntity : EntityBase, new()
	{
		public virtual IDbSession Dbsession { get; private set; }

		public SqlRepositoryBase(IDbSession dbsession)
		{
			Dbsession = dbsession;
			Mappings.Initialize();
		}

		#region 同步方法

		/// <summary>
		/// 根据主键获得一条记录
		/// </summary>
		/// <param name="id"></param>
		/// <param name="Dbsession.CommandTimeout"></param>
		/// <returns></returns>
		public virtual TEntity Get(Guid id)
		{
			return Dbsession.Connection.Get<TEntity>(id, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		/// <summary>
		/// 更新记录
		/// </summary>
		/// <param name="t"></param>
		/// <param name="Dbsession.CommandTimeout"></param>
		/// <returns></returns>
		public virtual bool Update(TEntity t)
		{
			return Dbsession.Connection.Update(t, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		/// <summary>
		/// 插入一条记录
		/// </summary>
		/// <param name="apply"></param>
		/// <param name="Dbsession.CommandTimeout"></param>
		/// <returns>新增记录的主键</returns>
		public virtual dynamic Insert(TEntity t)
		{
			return Dbsession.Connection.Insert(t, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		/// <summary>
		/// 批量插入记录
		/// </summary>
		/// <param name="entities"></param>
		/// <param name="Dbsession.CommandTimeout"></param>
		public virtual void Insert(IEnumerable<TEntity> entities)
		{
			Dbsession.Connection.Insert(entities, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		public virtual bool Delete(TEntity t)
		{
			return Dbsession.Connection.Delete(t, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		public virtual IEnumerable<TEntity> GetList(object predicate = null, IList<ISort> sort = null, bool buffered = false)
		{
			return Dbsession.Connection.GetList<TEntity>(predicate, sort, Dbsession.Transaction, Dbsession.CommandTimeout, buffered);
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
		/// <param name="Dbsession.CommandTimeout"></param>
		/// <param name="commandType"></param>
		/// <returns></returns>
		public virtual int Execute(string sql, object param = null, CommandType? commandType = null)
		{
			return Dbsession.Connection.Execute(sql, param, Dbsession.Transaction, Dbsession.CommandTimeout, commandType);
		}

		#endregion 同步方法

		#region 异步方法

		public virtual Task<TEntity> GetAsync(Guid id)
		{
			return Dbsession.Connection.GetAsync<TEntity>(id, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		public virtual Task<bool> UpdateAsync(TEntity t)
		{
			return Dbsession.Connection.UpdateAsync(t, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		public virtual Task<dynamic> InsertAsync(TEntity t)
		{
			return Dbsession.Connection.InsertAsync(t, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		public virtual Task InsertAsync(IEnumerable<TEntity> entities)
		{
			return Dbsession.Connection.InsertAsync(entities, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		public virtual Task<bool> DeleteAsync(TEntity t)
		{
			return Dbsession.Connection.DeleteAsync(t, Dbsession.Transaction, Dbsession.CommandTimeout);
		}

		public virtual Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null)
		{
			return Dbsession.Connection.ExecuteAsync(sql, param, Dbsession.Transaction, Dbsession.CommandTimeout, commandType);
		}

		#endregion 异步方法
	}
}