using System.IO;
using System.Web.Mvc;

namespace Views.Infrastructure
{
	public class DebugDataView : IView
	{

		public void Render(ViewContext viewContext, TextWriter writer)
		{

			this.Write(writer, "---Routing Data---");
			foreach(string key in viewContext.RouteData.Values.Keys)
			{
				this.Write(writer, "Key: {0}, Value: {1}", key, viewContext.RouteData.Values[key]);
			}

			this.Write(writer, "---View Data---");
			foreach(string key in viewContext.ViewData.Keys)
			{
				this.Write(writer, "Key: {0}, Value: {1}", key, viewContext.ViewData[key]);
			}
		}

		private void Write(TextWriter writer, string template, params object[] values)
		{
			writer.Write(string.Format(template, values) + "<p/>");
		}
	}
}
