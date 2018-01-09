using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Repository.SqlServer;
using Backend.WeChatApp.Utility.EnumTypes;
using Backend.WeChatApp.Utility.Extensions;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.WeChatApp.Repository.Extensions
{
	public static class UserInRoleRepositoryExtensions
	{
		public static IEnumerable<Role> GetUserRoles(this ISqlRepository<UserInRole> userRoleRepository, ISqlRepository<Role> roleRepository, Guid userId)
		{
			IEnumerable<Role> roles = Enumerable.Empty<Role>();

			if (userId != null)
			{
				userRoleRepository.SetCommandTimeout(3000);

				var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
				pg.Predicates.Add(Predicates.Field<UserInRole>(u => u.UserId, Operator.Eq, userId));
				pg.Predicates.Add(Predicates.Field<UserInRole>(u => u.Status, Operator.Eq, (int)Status.Yes));

				var userInRole = userRoleRepository.GetList(pg);

				if (userInRole.IsNotEmpty())
				{
					var userRoleKeys = userInRole.Select(x => x.Id).ToArray();

					pg.Predicates.Clear();
					pg.Predicates.Add(Predicates.Field<Role>(u => u.Id, Operator.Eq, userRoleKeys));
					pg.Predicates.Add(Predicates.Field<Role>(u => u.Status, Operator.Eq, (int)Status.Yes));

					roles = roleRepository.GetList(pg);
				}
			}

			return roles;
		}
	}
}