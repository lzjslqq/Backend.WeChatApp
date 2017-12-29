using Backend.WeChatApp.Domain.Entities.Core;
using System.Data.SqlClient;

namespace Backend.WeChatApp.Repository
{
	public interface ISqlRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
	{
		SqlConnection connection { get; set; }
	}
}