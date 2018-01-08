using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Repository.Sql;
using Backend.WeChatApp.Utility.EnumTypes;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Repository.Extensions
{
	public static class UserRepositoryExtensions
	{
		public static User GetSingleByUsername(this ISqlRepository<User> userRepository, string username)
		{
			User user = null;
			if (!string.IsNullOrEmpty(username))
			{
				var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
				pg.Predicates.Add(Predicates.Field<User>(u => u.Name, Operator.Eq, username));
				pg.Predicates.Add(Predicates.Field<User>(u => u.Status, Operator.Eq, (int)Status.Yes));

				user = userRepository.GetList(pg).FirstOrDefault();
			}

			return user;
		}
	}
}