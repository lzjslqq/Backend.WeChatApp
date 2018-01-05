using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.WeChatApp.API.MessageHandlers
{
	public class RequireHttpsMessageHandler : DelegatingHandler
	{
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
			{
				HttpResponseMessage forbiddenResponse = request.CreateResponse(HttpStatusCode.Forbidden);
				forbiddenResponse.ReasonPhrase = "请使用SSL连接访问";

				return Task.FromResult<HttpResponseMessage>(forbiddenResponse);
			}
			return base.SendAsync(request, cancellationToken);
		}
	}
}