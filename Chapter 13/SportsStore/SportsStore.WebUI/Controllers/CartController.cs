using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{

	public class CartController : Controller
	{
		private IProductRepository repository;
		private IOrderProcessor orderProcessor;

		public CartController(IProductRepository repo, IOrderProcessor proc)
		{
			this.repository = repo;
			this.orderProcessor = proc;
		}


		public ViewResult Index(Cart cart, string returnUrl)
		{
			return this.View(new CartIndexViewModel
			{
				ReturnUrl = returnUrl,
				Cart = cart
			});
		}

		public RedirectToRouteResult AddToCart(Cart cart, int productId,
				string returnUrl)
		{
			Product product = this.repository.Products
				.FirstOrDefault(p => p.ProductID == productId);

			if(product != null)
			{
				cart.AddItem(product, 1);
			}
			return this.RedirectToAction("Index", new
			{
				returnUrl
			});
		}

		public RedirectToRouteResult RemoveFromCart(Cart cart, int productId,
				string returnUrl)
		{
			Product product = this.repository.Products
				.FirstOrDefault(p => p.ProductID == productId);

			if(product != null)
			{
				cart.RemoveLine(product);
			}
			return this.RedirectToAction("Index", new
			{
				returnUrl
			});
		}

		public PartialViewResult Summary(Cart cart)
		{
			return this.PartialView(cart);
		}

		public ViewResult Checkout()
		{
			return this.View(new ShippingDetails());
		}

		[HttpPost]
		public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
		{
			if(cart.Lines.Count() == 0)
			{
				this.ModelState.AddModelError("", "Sorry, your cart is empty!");
			}

			if(this.ModelState.IsValid)
			{
				this.orderProcessor.ProcessOrder(cart, shippingDetails);
				cart.Clear();
				return this.View("Completed");
			}
			else
			{
				return this.View(shippingDetails);
			}
		}

	}
}
