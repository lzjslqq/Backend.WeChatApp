using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions.Mapper;
using DapperExtensions;

namespace Backend.WeChatApp.Repository
{
	public static class Mappings
	{
		public static void Initialize()
		{
			DapperExtensions.DapperExtensions.DefaultMapper = typeof(CustomPluralizedMapper<>);
		}
	}
}