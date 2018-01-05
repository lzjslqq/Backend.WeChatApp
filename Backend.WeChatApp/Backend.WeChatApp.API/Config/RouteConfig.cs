using Backend.WeChatApp.API.Routing;
using System.Web.Http;

namespace Backend.WeChatApp.API.Config
{
	public class RouteConfig
	{
		public static void RegisterRoutes(HttpConfiguration config)
		{
			var routes = config.Routes;

			routes.MapHttpRoute(
				"DefaultHttpRoute",
				"api/{controller}/{key}",
				defaults: new { id = RouteParameter.Optional },
				constraints: new { id = new GuidRouteConstraint() }
				);
		}
	}
}