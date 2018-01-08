using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Repository.Sql;
using Backend.WeChatApp.Utility.EnumTypes;
using Backend.WeChatApp.Utility.Extensions;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Repository.Extensions
{
	public static class UserRoleRepositoryExtensions
	{
		public static IEnumerable<Role> GetUserRoles(this ISqlRepository<UserRole> userRoleRepository, Guid userId)
		{
			IEnumerable<Role> roles = Enumerable.Empty<Role>();
			if (userId != null)
			{
				var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
				pg.Predicates.Add(Predicates.Field<UserRole>(u => u.UserId, Operator.Eq, userId));
				pg.Predicates.Add(Predicates.Field<UserRole>(u => u.Status, Operator.Eq, (int)Status.Yes));

				//var userRole = userRoleRepository.GetList(pg);

				//if (userRole.IsNotEmpty())
				//{
				//}
			}

			return roles;
		}
	}
}