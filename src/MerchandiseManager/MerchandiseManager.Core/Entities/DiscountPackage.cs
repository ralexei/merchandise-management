using MerchandiseManager.Core.Enums;
using MerchandiseManager.Core.Interfaces.Entity;
using System;

namespace MerchandiseManager.Core.Entities
{
	public partial class DiscountPackage : BaseEntity
	{
		public DiscountTypes DiscountType { get; private set; 
  }
		public decimal? MinAmount { get; private set; }
		public decimal? MaxAmount { get; private set; }

		public decimal? Percent { get; private set; }
		public decimal? DiscountSum { get; private set; }

		public Product Product { get; private set; }
		public Guid? ProductId { get; private set; }
	}
}
