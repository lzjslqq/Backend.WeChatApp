using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Service
{
	public interface IMembershipService
	{
		OperationResult<UserRole> CreateUser(string username, string email, string password);

		OperationResult<UserRole> CreateUser(string username, string email, string password, string role);

		OperationResult<UserRole> CreateUser(string username, string email, string password, string[] roles);

		UserRole UpdateUser(User user, string username, string email);

		bool ChangePassword(string username, string oldPassword, string newPassword);
	}
}