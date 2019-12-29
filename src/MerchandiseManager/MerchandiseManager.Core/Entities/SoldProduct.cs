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
	}
}
