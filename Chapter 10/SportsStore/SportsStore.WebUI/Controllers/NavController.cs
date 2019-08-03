using SportsStore.Domain.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{

	public class NavController : Controller
	{
		private IProductRepository repository;

		public NavController(IProductRepository repo)
		{
			this.repository = repo;
		}

		public PartialViewResult Menu(string category = null)
		{

			this.ViewBag.SelectedCategory = category;

			IEnumerable<string> categories = this.repository.Products
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x);

			return this.PartialView("FlexMenu", categories);
		}

	}
}
