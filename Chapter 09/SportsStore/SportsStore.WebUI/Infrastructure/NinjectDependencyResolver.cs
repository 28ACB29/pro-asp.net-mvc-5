using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure
{

	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel kernel;

		public NinjectDependencyResolver(IKernel kernelParam)
		{
			this.kernel = kernelParam;
			this.AddBindings();
		}

		public object GetService(Type serviceType)
		{
			return this.kernel
				.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this.kernel
				.GetAll(serviceType);
		}

		private void AddBindings()
		{
			this.kernel
				.Bind<IProductRepository>()
				.To<EFProductRepository>();

			EmailSettings emailSettings = new EmailSettings
			{
				WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
			};

			this.kernel
				.Bind<IOrderProcessor>()
				.To<EmailOrderProcessor>()
				.WithConstructorArgument("settings", emailSettings);
		}
	}
}
