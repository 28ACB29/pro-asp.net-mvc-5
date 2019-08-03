using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace SportsStore.Domain.Concrete
{

	public class EFProductRepository : IProductRepository
	{
		private EFDbContext context = new EFDbContext();

		public IEnumerable<Product> Products
		{
			get
			{
				return this.context.Products;
			}
		}

		public void SaveProduct(Product product)
		{

			if(product.ProductID == 0)
			{
				this.context.Products.Add(product);
			}
			else
			{
				Product dbEntry = this.context.Products.Find(product.ProductID);
				if(dbEntry != null)
				{
					dbEntry.Name = product.Name;
					dbEntry.Description = product.Description;
					dbEntry.Price = product.Price;
					dbEntry.Category = product.Category;
					dbEntry.ImageData = product.ImageData;
					dbEntry.ImageMimeType = product.ImageMimeType;
				}
			}
			this.context.SaveChanges();
		}

		public Product DeleteProduct(int productID)
		{
			Product dbEntry = this.context.Products.Find(productID);
			if(dbEntry != null)
			{
				this.context.Products.Remove(dbEntry);
				this.context.SaveChanges();
			}
			return dbEntry;
		}
	}
}