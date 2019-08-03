using HelperMethods.Models;
using System.Web.Mvc;

namespace HelperMethods.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{

			this.ViewBag.Fruits = new string[]
			{
				"Apple",
				"Orange",
				"Pear"
			};
			this.ViewBag.Cities = new string[]
			{
				"New York",
				"London",
				"Paris"
			};

			string message = "This is an HTML element: <input>";

			return this.View((object) message);
		}

		public ActionResult CreatePerson()
		{
			return this.View(new Person());
		}

		[HttpPost]
		public ActionResult CreatePerson(Person person)
		{
			return this.View(person);
		}
	}
}
