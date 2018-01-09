using DapperExtensions;

namespace Backend.WeChatApp.Repository.DapperExtensionCore
{
	public static class Mappings
	{
		public static void Initialize()
		{
			DapperExtensions.DapperExtensions.DefaultMapper = typeof(CustomPluralizedMapper<>);
			DapperAsyncExtensions.DefaultMapper = typeof(CustomPluralizedMapper<>);
		}
	}
}