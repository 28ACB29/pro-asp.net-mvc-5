using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entities
{

	public class Cart
	{
		private List<CartLine> lineCollection = new List<CartLine>();

		public void AddItem(Product product, int quantity)
		{
			CartLine line = this.lineCollection
				.Where(p => p.Product.ProductID == product.ProductID)
				.FirstOrDefault();

			if(line == null)
			{
				this.lineCollection.Add(new CartLine
				{
					Product = product,
					Quantity = quantity
				});
			}
			else
			{
				line.Quantity += quantity;
			}
		}

		public void RemoveLine(Product product)
		{
			this.lineCollection
				.RemoveAll(l => l.Product.ProductID == product.ProductID);
		}

		public decimal ComputeTotalValue()
		{
			return this.lineCollection
				.Sum(e => e.Product.Price * e.Quantity);

		}
		public void Clear()
		{
			this.lineCollection.Clear();
		}

		public IEnumerable<CartLine> Lines
		{
			get
			{
				return this.lineCollection;
			}
		}
	}

	public class CartLine
	{
		public Product Product
		{
			get;
			set;
		}
		public int Quantity
		{
			get;
			set;
		}
	}
}
