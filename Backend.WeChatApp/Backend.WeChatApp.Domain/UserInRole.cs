using Backend.WeChatApp.Entity;
using System;

namespace Backend.WeChatApp.Entity
{
	public class UserInRole : EntityBase
	{
		public Guid UserId { get; set; }
		public Guid RoleId { get; set; }
	}
}