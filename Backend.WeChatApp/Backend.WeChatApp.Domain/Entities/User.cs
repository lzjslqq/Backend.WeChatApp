using Backend.WeChatApp.Domain.Entities.Core;

namespace Backend.WeChatApp.Domain.Entities
{
	public class User : EntityBase
	{
		public string Name { get; set; }
		public string Email { get; set; }

		public string HashedPassword { get; set; }

		public string Salt { get; set; }
		public bool IsLocked { get; set; }
	}
}