using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class SoldProduct : IBaseEntity, IHasId<Guid>, IHasDate
	{
		public Guid Id { get; private set; }

		public DateTime CreationTime { get; private set; }
		public DateTime? UpdateTime { get; private set; }

		public decimal BuyPrice { get; private set; }
		public decimal SellPrice { get; private set; }

		public string BuyPriceCurrency { get; private set; }

		public Product Product { get; private set; }
		public Guid ProductGuid { get; private set; }

		public User Seller { get; private set; }
		public Guid SellerGuid { get; private set; }
	}
}
