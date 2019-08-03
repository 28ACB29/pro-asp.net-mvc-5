using HelperMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HelperMethods.Controllers
{
	public class PeopleController : Controller
	{
		private Person[] personData =
		{
			new Person
			{
				FirstName = "Adam",
				LastName = "Freeman",
				Role = Role.Admin
			},
			new Person
			{
				FirstName = "Jacqui",
				LastName = "Griffyth",
				Role = Role.User
			},
			new Person
			{
				FirstName = "John",
				LastName = "Smith",
				Role = Role.User
			},
			new Person
			{
				FirstName = "Anne",
				LastName = "Jones",
				Role = Role.Guest
			}
		};

		public ActionResult Index()
		{
			return this.View();
		}

		public ActionResult GetPeopleData(string selectedRole = "All")
		{
			IEnumerable<Person> data = this.personData;
			if(selectedRole != "All")
			{
				Role selected = (Role) Enum.Parse(typeof(Role), selectedRole);
				data = this.personData.Where(p => p.Role == selected);
			}
			if(this.Request.IsAjaxRequest())
			{
				var formattedData = data.Select(p => new
				{
					FirstName = p.FirstName,
					LastName = p.LastName,
					Role = Enum.GetName(typeof(Role), p.Role)
				});
				return this.Json(formattedData, JsonRequestBehavior.AllowGet);
			}
			else
			{
				return this.PartialView(data);
			}
		}

		public ActionResult GetPeople(string selectedRole = "All")
		{
			return this.View((object) selectedRole);
		}
	}
}
