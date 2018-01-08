using System;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using WebApiDoodle.Web.MessageHandlers;

namespace Backend.WeChatApp.API.MessageHandlers
{
	public class AuthHandler : BasicAuthenticationHandler
	{
		protected override Task<IPrincipal> AuthenticateUserAsync(HttpRequestMessage request, string username, string password, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}