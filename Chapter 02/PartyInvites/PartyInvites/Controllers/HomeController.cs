using PartyInvites.Models;
using System;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
	public class HomeController : Controller
	{

		public ViewResult Index()
		{
			int hour = DateTime.Now.Hour;
			this.ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
			return this.View();
		}

		[HttpGet]
		public ViewResult RsvpForm() => this.View();

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guestResponse)
		{
			if(this.ModelState.IsValid)
			{
				// TODO: Email response to the party organizer
				return this.View("Thanks", guestResponse);
			}
			else
			{
				// there is a validation error
				return this.View();
			}
		}
	}
}