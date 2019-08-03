using ControllerExtensibility.Infrastructure;
using ControllerExtensibility.Models;
using System.Web.Mvc;

namespace ControllerExtensibility.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			return this.View("Result", new Result
			{
				ControllerName = "Home",
				ActionName = "Index"
			});
		}

		[Local]
		[ActionName("Index")]
		public ActionResult LocalIndex()
		{
			return this.View("Result", new Result
			{
				ControllerName = "Home",
				ActionName = "LocalIndex"
			});
		}

		protected override void HandleUnknownAction(string actionName)
		{
			this.Response.Write(string.Format("You requested the {0} action", actionName));
		}
	}
}