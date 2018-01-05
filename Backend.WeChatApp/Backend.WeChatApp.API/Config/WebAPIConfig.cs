using System.Web.Http;
using System.Linq;
using System.Web.Http.ModelBinding;
using Backend.WeChatApp.API.Formatting;
using Backend.WeChatApp.API.Filters;
using System.Net.Http.Formatting;
using System.Web.Http.Validation;
using System.Web.Http.Validation.Providers;
using System.Security.Principal;
using Backend.WeChatApp.API.MessageHandlers;

namespace Backend.WeChatApp.API.Config
{
	public class WebAPIConfig
	{
		public static void Configure(HttpConfiguration config)
		{
			// Message Handlers
			config.MessageHandlers.Add(new RequireHttpsMessageHandler());

			// Formatters
			var jqueryFormatter = config.Formatters.FirstOrDefault(x => x.GetType() == typeof(JQueryMvcFormUrlEncodedFormatter));

			config.Formatters.Remove(config.Formatters.FormUrlEncodedFormatter);
			config.Formatters.Remove(jqueryFormatter);

			foreach (var formatter in config.Formatters)
			{
				formatter.RequiredMemberSelector = new SuppressedRequiredMemberSelector();
			}

			// Filters
			config.Filters.Add(new InvalidModelStateFilterAttribute());

			//Default Services

			// If ExcludeMatchOnTypeOnly is true then we don't match on type only which means
			// that we return null if we can't match on anything in the request. This is useful
			// for generating 406 (Not Acceptable) status codes.
			config.Services.Replace(typeof(IContentNegotiator),
				new DefaultContentNegotiator(excludeMatchOnTypeOnly: true));

			// Remove all the validation providers
			// except for DataAnnotationsModelValidatorProvider
			config.Services.RemoveAll(typeof(ModelValidatorProvider),
				validator => !(validator is DataAnnotationsModelValidatorProvider));

			// ParameterBindingRules

			//// Any complex type parameter which is Assignable From
			//// IRequestCommand will be bound from the URI
			//config.ParameterBindingRules.Insert(0, descriptor =>
			//	typeof(IRequestCommand).IsAssignableFrom(descriptor.ParameterType)
			//		? new FromUriAttribute().GetBinding(descriptor) : null);

			//// If the parameter type is IPrincipal,
			//// use PrincipalParameterBinding
			//config.ParameterBindingRules.Add(typeof(IPrincipal),
			//	descriptor => new PrincipalParameterBinding(descriptor));
		}
	}
}