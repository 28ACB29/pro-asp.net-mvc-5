using System.Diagnostics;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
	public class ProfileResultAttribute : FilterAttribute, IResultFilter
	{
		private Stopwatch timer;

		public void OnResultExecuting(ResultExecutingContext filterContext)
		{
			this.timer = Stopwatch.StartNew();
		}

		public void OnResultExecuted(ResultExecutedContext filterContext)
		{
			this.timer.Stop();
			filterContext.HttpContext.Response.Write(string.Format("<div>Result elapsed time: {0:F6}</div>", this.timer.Elapsed.TotalSeconds));
		}
	}
}
