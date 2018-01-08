using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Utility.Extensions
{
	public static class ListExtensions
	{
		public static bool IsNotEmpty(this IEnumerable<object> list)
		{
			return list != null && list.Count() > 0;
		}
	}
}