using Backend.WeChatApp.Domain.Entities.Core;
using System;

namespace Backend.WeChatApp.Domain.Entities
{
	public class UserRole : EntityBase
	{
		public Guid UserId { get; set; }
		public Guid RoleId { get; set; }
	}
}