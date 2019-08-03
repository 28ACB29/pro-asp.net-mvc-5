using System;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{

	public class ExampleController : Controller
	{

		public ViewResult Index()
		{

			this.ViewBag.Message = "Hello";
			this.ViewBag.Date = DateTime.Now;

			return this.View();
		}

		public RedirectToRouteResult Redirect()
		{
			return this.RedirectToAction("Index", "Basic");
		}

		public HttpStatusCodeResult StatusCode()
		{
			return new HttpUnauthorizedResult();
		}



	}
}
