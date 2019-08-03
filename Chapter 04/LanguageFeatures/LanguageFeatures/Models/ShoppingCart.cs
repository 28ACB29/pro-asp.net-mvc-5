using System.Collections;
using System.Collections.Generic;

namespace LanguageFeatures.Models
{

	public class ShoppingCart : IEnumerable<Product>
	{

		public List<Product> Products
		{
			get;
			set;
		}

		public IEnumerator<Product> GetEnumerator()
		{
			return this.Products.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
