using ClientFeatures.Models;
using System.Web.Mvc;

namespace ClientFeatures.Controllers
{
	public class HomeController : Controller
	{

		public ViewResult MakeBooking()
		{
			return this.View(new Appointment
			{
				ClientName = "Adam",
				TermsAccepted = true
			});
		}

		[HttpPost]
		public JsonResult MakeBooking(Appointment appt)
		{
			// statements to store new Appointment in a
			// repository would go here in a real project
			return this.Json(appt, JsonRequestBehavior.AllowGet);
		}
	}
}
