using System;
using System.Web.Mvc;

namespace WorkingWithRazor.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			string[] names = { "Apple", "Orange", "Pear" };
			return this.View(names);
		}

		public ActionResult List()
		{
			return this.View();
		}

		[ChildActionOnly]
		public ActionResult Time()
		{
			return this.PartialView(DateTime.Now);
		}
	}
}