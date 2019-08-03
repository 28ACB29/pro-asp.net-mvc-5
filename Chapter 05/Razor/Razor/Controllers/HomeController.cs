using Razor.Models;
using System.Web.Mvc;

namespace Razor.Controllers
{

	public class HomeController : Controller
	{
		private Product myProduct = new Product
		{
			ProductID = 1,
			Name = "Kayak",
			Description = "A boat for one person",
			Category = "Watersports",
			Price = 275M
		};

		public ActionResult Index()
		{
			return this.View(this.myProduct);
		}

		public ActionResult NameAndPrice()
		{
			return this.View(this.myProduct);
		}

		public ActionResult DemoExpression()
		{

			this.ViewBag.ProductCount = 1;
			this.ViewBag.ExpressShip = true;
			this.ViewBag.ApplyDiscount = false;
			this.ViewBag.Supplier = null;

			return this.View(this.myProduct);
		}

		public ActionResult DemoArray()
		{

			Product[] array =
			{
				new Product
				{
					Name = "Kayak",
					Price = 275M
				},
				new Product
				{
					Name = "Lifejacket",
					Price = 48.95M
				},
				new Product
				{
					Name = "Soccer ball",
					Price = 19.50M
				},
				new Product
				{
					Name = "Corner flag",
					Price = 34.95M
				}
			};
			return this.View(array);
		}
	}
}