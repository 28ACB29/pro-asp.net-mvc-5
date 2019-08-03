using MvcModels.Infrastructure;
using System.Web.Mvc;

namespace MvcModels.Models
{

	[ModelBinder(typeof(AddressSummaryBinder))]
	public class AddressSummary
	{
		public string City
		{
			get;
			set;
		}
		public string Country
		{
			get;
			set;
		}
	}
}
