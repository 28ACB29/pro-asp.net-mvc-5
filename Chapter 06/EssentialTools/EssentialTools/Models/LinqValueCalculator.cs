﻿using System.Collections.Generic;
using System.Linq;

namespace EssentialTools.Models
{

	public class LinqValueCalculator : IValueCalculator
	{
		private IDiscountHelper discounter;
		private static int counter = 0;

		public LinqValueCalculator(IDiscountHelper discountParam)
		{
			this.discounter = discountParam;
			System.Diagnostics.Debug.WriteLine(string.Format("Instance {0} created", ++counter));
		}

		public decimal ValueProducts(IEnumerable<Product> products)
		{
			return this.discounter.ApplyDiscount(products.Sum(p => p.Price));
		}
	}
}
