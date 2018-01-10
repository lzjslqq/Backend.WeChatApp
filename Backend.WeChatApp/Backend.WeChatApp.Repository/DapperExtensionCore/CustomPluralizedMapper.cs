using DapperExtensions.Mapper;
using System;

namespace Backend.WeChatApp.Repository.DapperExtensionCore
{
	public class CustomPluralizedMapper<T> : PluralizedAutoClassMapper<T> where T : class
	{
		public override void Table(string tableName)
		{
			if (tableName.Equals("UserInRole", StringComparison.CurrentCultureIgnoreCase))
			{
				TableName = "UserRole";
				Schema("dbo");
			}

			base.Table(tableName);
		}
	}
}