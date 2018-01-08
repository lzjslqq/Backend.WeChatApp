using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Service.Interfaces
{
	public interface IMembershipService
	{
		ValidUserContext ValidateUser(string username, string password);

		OperationResult<UserWithRoles> CreateUser(string username, string email, string password);

		OperationResult<UserWithRoles> CreateUser(string username, string email, string password, string role);

		OperationResult<UserWithRoles> CreateUser(string username, string email, string password, string[] roles);

		UserWithRoles UpdateUser(User user, string username, string email);

		bool ChangePassword(string username, string oldPassword, string newPassword);

		bool AddToRole(Guid userId, string role);

		bool AddToRole(string username, string role);

		bool RemoveFromRole(string username, string role);

		IEnumerable<Role> GetRoles();

		Role GetRole(Guid key);

		Role GetRole(string name);

		UserWithRoles GetUser(Guid id);

		UserWithRoles GetUser(string name);
	}
}