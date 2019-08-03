﻿using EssentialTools.Models;
using System.Web.Mvc;

namespace EssentialTools.Controllers
{

	public class HomeController : Controller
	{
		private IValueCalculator calc;
		private Product[] products = {
			new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
			new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
			new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
			new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
		};

		public HomeController(IValueCalculator calcParam, IValueCalculator calc2)
		{
			this.calc = calcParam;
		}

		public ActionResult Index()
		{

			ShoppingCart cart = new ShoppingCart(this.calc) { Products = products };

			decimal totalValue = cart.CalculateProductTotal();

			return this.View(totalValue);
		}
	}
}
