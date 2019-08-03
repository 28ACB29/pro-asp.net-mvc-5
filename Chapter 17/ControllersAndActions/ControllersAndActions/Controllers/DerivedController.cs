using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
	public class DerivedController : Controller
	{

		public ActionResult Index()
		{
			this.ViewBag.Message = "Hello from the DerivedController Index method";
			return this.View("MyView");
		}

		public ActionResult ProduceOutput()
		{
			return this.Redirect("/Basic/Index");
		}


	}
}
