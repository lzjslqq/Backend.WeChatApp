using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.WeChatApp.API.Test.TestHelpers
{
	internal static class DelegatingHandlerExtensions
	{
		internal static Task<HttpResponseMessage> InvokeAsync(this DelegatingHandler handler, HttpRequestMessage request, CancellationToken cancellationToken = default(CancellationToken))
		{
			handler.InnerHandler = new DummyHandler();
			var invoker = new HttpMessageInvoker(handler);
			return invoker.SendAsync(request, cancellationToken);
		}

		private class DummyHandler : HttpMessageHandler
		{
			protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
			{
				var response = new HttpResponseMessage(HttpStatusCode.OK);
				return Task.FromResult(response);
			}
		}
	}
}