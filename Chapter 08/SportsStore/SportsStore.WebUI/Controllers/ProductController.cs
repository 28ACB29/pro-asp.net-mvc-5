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

		public ViewResult List(string category, int page = 1)
		{

			ProductsListViewModel viewModel = new ProductsListViewModel
			{
				Products = this.repository.Products
					.Where(p => category == null || p.Category == category)
					.OrderBy(p => p.ProductID)
					.Skip((page - 1) * this.PageSize)
					.Take(this.PageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems = category ==
						null ?
						this.repository.Products.Count() :
						this.repository.Products.Where(e => e.Category == category).Count()
				},
				CurrentCategory = category
			};
			return this.View(viewModel);
		}

	}
}
