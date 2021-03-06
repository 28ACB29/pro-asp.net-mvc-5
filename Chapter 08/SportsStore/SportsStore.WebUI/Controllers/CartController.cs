﻿using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{

	public class CartController : Controller
	{
		private IProductRepository repository;

		public CartController(IProductRepository repo)
		{
			this.repository = repo;
		}

		public ViewResult Index(string returnUrl)
		{
			return this.View(new CartIndexViewModel
			{
				Cart = this.GetCart(),
				ReturnUrl = returnUrl
			});
		}

		public RedirectToRouteResult AddToCart(int productId, string returnUrl)
		{
			Product product = this.repository
				.Products
				.FirstOrDefault(p => p.ProductID == productId);

			if(product != null)
			{
				this.GetCart().AddItem(product, 1);
			}
			return this.RedirectToAction("Index", new
			{
				returnUrl
			});
		}

		public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
		{
			Product product = this.repository
				.Products
				.FirstOrDefault(p => p.ProductID == productId);

			if(product != null)
			{
				this.GetCart().RemoveLine(product);
			}
			return this.RedirectToAction("Index", new
			{
				returnUrl
			});
		}

		private Cart GetCart()
		{

			Cart cart = (Cart) this.Session["Cart"];
			if(cart == null)
			{
				cart = new Cart();
				this.Session["Cart"] = cart;
			}
			return cart;
		}
	}
}
