using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
	public class AdminController : Controller
	{

		public ActionResult Index()
		{
			this.ViewBag.Controller = "Admin";
			this.ViewBag.Action = "Index";
			return this.View("ActionName");
		}
	}
}