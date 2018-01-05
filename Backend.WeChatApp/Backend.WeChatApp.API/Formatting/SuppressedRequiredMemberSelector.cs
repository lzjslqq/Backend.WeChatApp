using System.Net.Http.Formatting;
using System.Reflection;

namespace Backend.WeChatApp.API.Formatting
{
	public class SuppressedRequiredMemberSelector : IRequiredMemberSelector
	{
		public bool IsRequiredMember(MemberInfo member)
		{
			return false;
		}
	}
}