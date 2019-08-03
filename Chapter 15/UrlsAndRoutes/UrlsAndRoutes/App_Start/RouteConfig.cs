using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
	public class RouteConfig
	{

		public static void RegisterRoutes(RouteCollection routes)
		{

			routes.MapMvcAttributeRoutes();

			routes.MapRoute("Default", "{controller}/{action}/{id}",
			new
			{
				controller = "Home",
				action = "Index",
				id = UrlParameter.Optional
			},
			new[]
			{
				"UrlsAndRoutes.Controllers"
			});
		}
	}
}
