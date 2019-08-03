using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			this.ViewBag.Controller = "Home";
			this.ViewBag.Action = "Index";
			return this.View("ActionName");
		}

		public ActionResult CustomVariable(string id = "DefaultId")
		{
			this.ViewBag.Controller = "Home";
			this.ViewBag.Action = "CustomVariable";
			this.ViewBag.CustomVariable = id;
			return this.View();
		}

		public RedirectToRouteResult MyActionMethod()
		{
			return this.RedirectToRoute(
			new
			{
				controller = "Home",
				action = "Index",
				id = "MyID"
			});
		}



	}
}
