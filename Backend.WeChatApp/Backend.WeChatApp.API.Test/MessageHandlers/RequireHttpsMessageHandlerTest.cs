using Backend.WeChatApp.API.MessageHandlers;
using Backend.WeChatApp.API.Test.TestHelpers;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backend.WeChatApp.API.Test.MessageHandlers
{
	public class RequireHttpsMessageHandlerTest
	{
		[Test]
		public async Task Returns_Forbidden_If_Request_Is_Not_Over_HTTPS()
		{
			// 准备
			var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080");
			var requireHtttpsMessageHandler = new RequireHttpsMessageHandler();

			// 动作
			var response = await requireHtttpsMessageHandler.InvokeAsync(request);

			// 断言
			Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
			Console.WriteLine(response.ReasonPhrase);
		}

		[Test]
		public async Task Returns_Delegated_StatusCode_If_Request_Is_Over_HTTPS()
		{
			// 准备
			var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:8080");
			var requireHtttpsMessageHandler = new RequireHttpsMessageHandler();

			// 动作
			var response = await requireHtttpsMessageHandler.InvokeAsync(request);

			// 断言
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}
	}
}