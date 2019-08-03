using ControllerExtensibility.Models;
using System.Web.Mvc;

namespace ControllerExtensibility.Controllers
{
	public class ProductController : Controller
	{

		public ViewResult Index()
		{
			return this.View("Result", new Result
			{
				ControllerName = "Product",
				ActionName = "Index"
			});
		}

		public ViewResult List()
		{
			return this.View("Result", new Result
			{
				ControllerName = "Product",
				ActionName = "List"
			});
		}
	}
}
