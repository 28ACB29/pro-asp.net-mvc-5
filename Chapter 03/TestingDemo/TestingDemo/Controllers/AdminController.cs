using System.Web.Mvc;

namespace TestingDemo
{

	public class AdminController : Controller
	{
		private IUserRepository repository;

		public AdminController(IUserRepository repo)
		{
			this.repository = repo;
		}

		public ActionResult ChangeLoginName(string oldName, string newName)
		{
			User user = this.repository.FetchByLoginName(oldName);
			user.LoginName = newName;
			this.repository.SubmitChanges();
			// render some view to show the result
			return this.View();
		}
	}
}
