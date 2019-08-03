﻿using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
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
			return this.kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this.kernel.GetAll(serviceType);
		}

		private void AddBindings()
		{
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<Product>
			{
				new Product
				{
					Name = "Football",
					Price = 25
				},
				new Product
				{
					Name = "Surf board",
					Price = 179
				},
				new Product
				{
					Name = "Running shoes",
					Price = 95
				}
			});

			//this.kernel.Bind<IProductRepository>().ToConstant(mock.Object);
			this.kernel.Bind<IProductRepository>().To<EFProductRepository>();
		}
	}
}
