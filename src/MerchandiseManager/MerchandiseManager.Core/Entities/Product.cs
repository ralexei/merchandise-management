using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class Product : IBaseEntity, IHasId<Guid>, IHasDate
	{
		public Guid Id { get; private set; }

		public DateTime CreationTime { get; private set; }
		public DateTime? UpdateTime { get; private set; }

		public string ProductName { get; private set; }
		public string ProductDescription { get; private set; }

		public decimal BuyPrice { get; private set; }
		public decimal RetailSellPrice { get; private set; }
		public decimal WholesaleSellPrice { get; private set; }

		public Category Category { get; private set; }
		public Guid CategoryGuid { get; private set; }
	}
}
