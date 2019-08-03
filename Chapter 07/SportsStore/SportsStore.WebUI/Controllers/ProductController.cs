using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{

	public class ProductController : Controller
	{
		private IProductRepository repository;
		public int PageSize = 4;

		public ProductController(IProductRepository productRepository)
		{
			this.repository = productRepository;
		}

		public ViewResult List(int page = 1)
		{
			//return View(repository.Products);
			ProductsListViewModel model = new ProductsListViewModel
			{
				Products = this.repository.Products
				.OrderBy(p => p.ProductID)
				.Skip((page - 1) * this.PageSize)
				.Take(this.PageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems = this.repository.Products.Count()
				}
			};
			return this.View(model);
		}
	}
}