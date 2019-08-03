namespace EssentialTools.Models
{

	public interface IDiscountHelper
	{
		decimal ApplyDiscount(decimal totalParam);
	}

	public class DefaultDiscountHelper : IDiscountHelper
	{
		public decimal discountSize;

		public DefaultDiscountHelper(decimal discountParam)
		{
			this.discountSize = discountParam;
		}

		public decimal ApplyDiscount(decimal totalParam)
		{
			return (totalParam - (this.discountSize / 100m * totalParam));
		}
	}
}
