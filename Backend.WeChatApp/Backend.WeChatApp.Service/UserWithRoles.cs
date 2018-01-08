using Backend.WeChatApp.Entity;
using System.Collections.Generic;

namespace Backend.WeChatApp.Service
{
	public class UserWithRoles
	{
		public User User { get; set; }
		public IEnumerable<Role> Roles { get; set; }
	}
}