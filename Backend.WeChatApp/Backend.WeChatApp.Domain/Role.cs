using Backend.WeChatApp.Entity;
using System;

namespace Backend.WeChatApp.Entity
{
	public class Role : EntityBase
	{
		public string Name { get; set; }
		public int Level { get; set; }
	}
}