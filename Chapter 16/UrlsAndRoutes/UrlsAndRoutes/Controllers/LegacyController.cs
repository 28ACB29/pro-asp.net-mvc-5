using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{

	public class LegacyController : Controller
	{

		public ActionResult GetLegacyURL(string legacyURL)
		{
			return this.View((object) legacyURL);
		}
	}
}
