using Backend.WeChatApp.Domain.Entities.Core;
using Backend.WeChatApp.Repository.Core;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace Backend.WeChatApp.Repository
{
	public class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
	{
		protected IDbSession _dbsession;

		public SqlRepository(IDbSession dbsession)
		{
			_dbsession = dbsession;
		}

		public IEnumerable<TEntity> GetList(object predicate = null, IList<ISort> sort = null)
		{
			return _dbsession.Connection.GetList<TEntity>(predicate, sort, _dbsession.Transaction);
		}

		public TEntity Get(Guid id)
		{
			return _dbsession.Connection.Get<TEntity>(id, _dbsession.Transaction);
		}

		public bool Update(TEntity entity)
		{
			return _dbsession.Connection.Update(entity, _dbsession.Transaction);
		}

		public TEntity Insert(TEntity apply)
		{
			return _dbsession.Connection.Insert(apply, _dbsession.Transaction);
		}

		public bool Delete(TEntity t)
		{
			return _dbsession.Connection.Delete(t, _dbsession.Transaction);
		}
	}
}