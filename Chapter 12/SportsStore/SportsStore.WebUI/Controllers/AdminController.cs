using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{

	[Authorize]
	public class AdminController : Controller
	{
		private IProductRepository repository;

		public AdminController(IProductRepository repo)
		{
			this.repository = repo;
		}

		public ViewResult Index()
		{
			return this.View(this.repository.Products);
		}

		public ViewResult Edit(int productId)
		{
			Product product = this.repository.Products
				.FirstOrDefault(p => p.ProductID == productId);
			return this.View(product);
		}

		[HttpPost]
		public ActionResult Edit(Product product, HttpPostedFileBase image = null)
		{
			if(this.ModelState.IsValid)
			{
				if(image != null)
				{
					product.ImageMimeType = image.ContentType;
					product.ImageData = new byte[image.ContentLength];
					image.InputStream.Read(product.ImageData, 0, image.ContentLength);
				}
				this.repository.SaveProduct(product);
				this.TempData["message"] = string.Format("{0} has been saved", product.Name);
				return this.RedirectToAction("Index");
			}
			else
			{
				// there is something wrong with the data values
				return this.View(product);
			}
		}

		public ViewResult Create()
		{
			return this.View("Edit", new Product());
		}

		[HttpPost]
		public ActionResult Delete(int productId)
		{
			Product deletedProduct = this.repository.DeleteProduct(productId);
			if(deletedProduct != null)
			{
				this.TempData["message"] = string.Format("{0} was deleted",
					deletedProduct.Name);
			}
			return this.RedirectToAction("Index");
		}
	}
}
