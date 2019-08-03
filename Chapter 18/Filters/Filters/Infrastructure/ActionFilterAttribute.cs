using System.Diagnostics;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
	public class ProfileAllAttribute : ActionFilterAttribute
	{
		private Stopwatch timer;

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			this.timer = Stopwatch.StartNew();
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			this.timer.Stop();
			filterContext.HttpContext.Response.Write(string.Format("<div>Total elapsed time: {0:F6}</div>", this.timer.Elapsed.TotalSeconds));
		}
	}
}
