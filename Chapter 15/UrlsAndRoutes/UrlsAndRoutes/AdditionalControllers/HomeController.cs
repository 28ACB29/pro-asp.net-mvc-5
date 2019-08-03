using System.Web.Mvc;

namespace UrlsAndRoutes.AdditionalControllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			this.ViewBag.Controller = "Additional Controllers - Home";
			this.ViewBag.Action = "Index";
			return this.View("ActionName");
		}
	}
}