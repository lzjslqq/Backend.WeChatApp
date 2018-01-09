using Backend.WeChatApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Repository.SqlServer
{
	public static class SqlRepositoryExtensions
	{
		public static ISqlRepository<TEntity> SetCommandTimeout<TEntity>(this ISqlRepository<TEntity> sqlRepository, int timeout) where TEntity : EntityBase, new()
		{
			if (timeout >= 0)
			{
				sqlRepository.Dbsession.CommandTimeout = timeout;
			}
			return sqlRepository;
		}
	}
}