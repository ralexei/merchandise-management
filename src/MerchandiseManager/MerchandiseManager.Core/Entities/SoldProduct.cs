using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class SoldProduct : BaseEntity 
	{
		public decimal BuyPrice { get; private set; }
		public decimal SellPrice { get; private set; }

		public string BuyPriceCurrency { get; private set; }

		public Product Product { get; private set; }
		public Guid ProductId { get; private set; }

		public User Seller { get; private set; }
		public Guid SellerId { get; private set; }

		public static SoldProduct SellProduct(Product product, Guid sellerId, bool isWholesale = false)
		{
			return new SoldProduct
			{
				BuyPrice = product.BuyPrice.Value,
				BuyPriceCurrency = "MDL", //@TODO-HARDCODE
				ProductId = product.Id,
				SellerId = sellerId,
				SellPrice = GetProductSellPrice(product, isWholesale)
			};
		}

		private static decimal GetProductSellPrice(Product product, bool isWholsale)
		{
			if (isWholsale)
				return product.WholesaleSellPrice ?? throw new Exception("Product has no wholesale price");
			else
				return product.RetailSellPrice ?? throw new Exception("Product has no retail price");
		}
	}
}
