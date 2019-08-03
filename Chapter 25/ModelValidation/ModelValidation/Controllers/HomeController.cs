using ModelValidation.Models;
using System;
using System.Web.Mvc;

namespace ModelValidation.Controllers
{
	public class HomeController : Controller
	{

		public ViewResult MakeBooking()
		{
			return this.View(new Appointment { Date = DateTime.Now });
		}

		[HttpPost]
		public ViewResult MakeBooking(Appointment appt)
		{
			if(this.ModelState.IsValid)
			{
				// statements to store new Appointment in a
				// repository would go here in a real project
				return this.View("Completed", appt);
			}
			else
			{
				return this.View();
			}
		}

		public JsonResult ValidateDate(string Date)
		{

			if(!DateTime.TryParse(Date, out DateTime parsedDate))
			{
				return this.Json("Please enter a valid date (mm/dd/yyyy)", JsonRequestBehavior.AllowGet);
			}
			else if(DateTime.Now > parsedDate)
			{
				return this.Json("Please enter a date in the future", JsonRequestBehavior.AllowGet);
			}
			else
			{
				return this.Json(true, JsonRequestBehavior.AllowGet);
			}
		}


	}
}
