using System.Web.Mvc;

namespace WebServices.Controllers
{

	public class HomeController : Controller
	{

		public ViewResult Index()
		{
			return this.View();
		}
	}
}
