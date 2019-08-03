using EssentialTools.Models;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EssentialTools.Infrastructure
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
			return this.kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this.kernel.GetAll(serviceType);
		}

		private void AddBindings()
		{
			this.kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
			this.kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);
			this.kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
		}
	}
}
