using System.Web.Mvc;

namespace UrlsAndRoutes.Areas.Admin.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			return this.View();
		}
	}
}
