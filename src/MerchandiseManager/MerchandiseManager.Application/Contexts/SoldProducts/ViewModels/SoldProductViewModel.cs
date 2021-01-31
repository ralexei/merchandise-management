using MerchandiseManager.Application.Contexts.Products.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.SoldProducts.ViewModels
{
	public class SoldProductViewModel
	{
		public decimal SellPrice { get; private set; }

		public string BuyPriceCurrency { get; private set; }

		public int SoldAmount { get; private set; }

		public ProductViewModel Product { get; private set; }
		public Guid ProductId { get; private set; }

		//public User Seller { get; private set; }
		//public Guid SellerId { get; private set; }
	}
}
