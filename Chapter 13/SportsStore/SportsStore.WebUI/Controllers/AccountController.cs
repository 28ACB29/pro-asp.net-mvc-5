using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{

	public class AccountController : Controller
	{
		private IAuthProvider authProvider;

		public AccountController(IAuthProvider auth)
		{
			this.authProvider = auth;
		}

		public ViewResult Login()
		{
			return this.View();
		}

		[HttpPost]
		public ActionResult Login(LoginViewModel model, string returnUrl)
		{

			if(this.ModelState.IsValid)
			{
				if(this.authProvider.Authenticate(model.UserName, model.Password))
				{
					return this.Redirect(returnUrl ?? this.Url.Action("Index", "Admin"));
				}
				else
				{
					this.ModelState.AddModelError("", "Incorrect username or password");
					return this.View();
				}
			}
			else
			{
				return this.View();
			}
		}
	}
}
