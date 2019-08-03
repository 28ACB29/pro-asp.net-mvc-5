using System;
using System.Web.Mvc;

namespace Views.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			string[] names = { "Apple", "Orange", "Pear" };
			this.ViewBag.Message = "Hello, World";
			this.ViewBag.Time = DateTime.Now.ToShortTimeString();
			return this.View("DebugData");
		}

		public ActionResult List()
		{
			return this.View();
		}
	}
}
