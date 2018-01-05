using System;

namespace Backend.WeChatApp.Entity
{
	public class EntityBase
	{
		public Guid Id { get; set; }
		public DateTime UpdateTime { get; set; }
		public DateTime CreateTime { get; set; }
	}
}