using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Repository.SqlServer;
using Backend.WeChatApp.Utility.EnumTypes;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;

namespace Backend.WeChatApp.Repository.Extensions
{
	public static class RoleRepositoryExtensions
	{
		public static Role GetSingleByRoleName(this ISqlRepository<Role> roleRepository, string roleName)
		{
			Role role = null;
			if (!string.IsNullOrEmpty(roleName))
			{
				roleRepository.SetCommandTimeout(3000);
				var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
				pg.Predicates.Add(Predicates.Field<Role>(u => u.Name, Operator.Eq, roleName));
				pg.Predicates.Add(Predicates.Field<Role>(u => u.Status, Operator.Eq, (int)Status.Yes));

				role = roleRepository.GetList(pg).FirstOrDefault();
			}

			return role;
		}
	}
}