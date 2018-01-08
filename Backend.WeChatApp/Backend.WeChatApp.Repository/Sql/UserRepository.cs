using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Repository.Core;
using Backend.WeChatApp.Utility.EnumTypes;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;

namespace Backend.WeChatApp.Repository.Sql
{
	public class UserRepository : SqlRepositoryBase<User>
	{
		public UserRepository(IDbSession dbsession)
			: base(dbsession)
		{
		}

		/// <summary>
		///    To create a simple predicate, just create a FieldPredicate and pass it to the query operation. FieldPredicate expects a generic   type which allows for strong typing.
		/// </summary>
		/// <returns></returns>
		public User GetUser(string username)
		{
			// select * from user where name = true;
			// Demonstrate that you can pass an IEnumerable as the value to acheive WHERE x IN ('a','b') functionality
			var predicate = Predicates.Field<User>(u => u.Name, Operator.Eq, username);
			return GetList(predicate).FirstOrDefault();
		}

		/// <summary>
		///  Compound predicates are achieved through the use of predicate groups. For each predicate group, you must choose an operator (AND/OR). Each predicate that is added to the group will be joined with the specified operator.
		///  Multiple predicate groups can be joined together since each predicate group implements IPredicate.
		///  In the example below, we create a predicate group with an AND operator:
		/// </summary>
		/// <returns></returns>
		public User GetSingleByUsername(string username)
		{
			// select * from user where name = @username and Status = 1;
			// 传入一个 IEnumerable 类型作为 value的值可以实现 WHERE x IN ('a','b') 功能。
			var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
			pg.Predicates.Add(Predicates.Field<User>(u => u.Name, Operator.Eq, username));
			pg.Predicates.Add(Predicates.Field<User>(u => u.Status, Operator.Eq, (int)Status.Yes));

			return GetList(pg).FirstOrDefault();
		}

		/// <summary>
		/// 因为 predicate groups 实现了 IPredicate，所以我们可以连接多个PredicateGroup来组成一个复杂的混合谓词语句
		/// Since each predicate groups implement IPredicate, you can chain them together to create complex compound predicates.
		/// In the example below, we create two predicate groups and then join them together with a third predicate group
		/// </summary>
		/// <returns></returns>
		public IEnumerable<User> GetUsers3()
		{
			// select * from user where ((name like 'li%') and (islocked = true)) or ((name not like 'Pa%') and (islocked = false));

			var pgMain = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };

			var pga = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
			pga.Predicates.Add(Predicates.Field<User>(u => u.Name, Operator.Like, "li%"));
			pga.Predicates.Add(Predicates.Field<User>(u => u.IsLocked, Operator.Eq, true));
			pgMain.Predicates.Add(pga);

			var pgb = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
			pgb.Predicates.Add(Predicates.Field<User>(u => u.IsLocked, Operator.Eq, false));
			pgb.Predicates.Add(Predicates.Field<User>(u => u.Name, Operator.Like, "Pa%", true /* NOT */ ));
			pgMain.Predicates.Add(pgb);

			return GetList(pgMain);
		}

		/// <summary>
		/// Property Predicates 可用来比较两个表里的值.
		//  In the example below, we are returning all User where the FirstName value is equal to the PreferredName value.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<User> GetUsers4()
		{
			// select * from user where user.name = user.email;

			var predicate = Predicates.Property<User, User>(u => u.Name, Operator.Eq, p => p.Email);

			return GetList(predicate);
		}

		public IEnumerable<User> GetUsers5()
		{
			// select * from user where user.name = user.email;

			var subPred = Predicates.Field<User>(u => u.Email, Operator.Eq, "someone@somewhere.com");
			var existsPred = Predicates.Exists<User>(subPred);
			return GetList(existsPred);
		}
	}
}