using Backend.WeChatApp.Entity;
using System;

namespace Backend.WeChatApp.Entity
{
	public class User : EntityBase
	{
		public string Name { get; set; }
		public string Nickname { get; set; }
		public int Age { get; set; }
		public int Sex { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public int Level { get; set; }
		public string Agent { get; set; }

		public string HashedPassword { get; set; }

		public string Salt { get; set; }
		public bool IsLocked { get; set; }
	}
}