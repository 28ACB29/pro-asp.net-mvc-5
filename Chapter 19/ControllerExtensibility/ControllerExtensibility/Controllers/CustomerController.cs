using ControllerExtensibility.Models;
using System.Web.Mvc;

namespace ControllerExtensibility.Controllers
{
	public class CustomerController : Controller
	{

		public ViewResult Index()
		{
			return this.View("Result", new Result
			{
				ControllerName = "Customer",
				ActionName = "Index"
			});
		}

		[ActionName("Enumerate")]
		public ViewResult List()
		{
			return this.View("Result", new Result
			{
				ControllerName = "Customer",
				ActionName = "List"
			});
		}

		[NonAction]
		public ActionResult MyAction()
		{
			return this.View();
		}
	}
}
