using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Backend.WeChatApp.API.Routing
{
	public class GuidRouteConstraint : IHttpRouteConstraint
	{
		private const string _format = "D";

		public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
		{
			if (values[parameterName] != RouteParameter.Optional)
			{
				object value;
				values.TryGetValue(parameterName, out value);
				string input = Convert.ToString(value, CultureInfo.InvariantCulture);

				Guid guidValue;
				return Guid.TryParseExact(input, _format, out guidValue);
			}

			return true;
		}
	}
}