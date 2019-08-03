using System.Web.Mvc;
using System.Web.Security;

namespace Filters.Controllers
{
	public class GoogleAccountController : Controller
	{

		public ActionResult Login()
		{
			return this.View();
		}

		[HttpPost]
		public ActionResult Login(string username, string password, string returnUrl)
		{
			if(username.EndsWith("@google.com") && password == "secret")
			{
				FormsAuthentication.SetAuthCookie(username, false);
				return this.Redirect(returnUrl ?? this.Url.Action("Index", "Home"));
			}
			else
			{
				this.ModelState.AddModelError("", "Incorrect username or password");
				return this.View();
			}
		}
	}
}
