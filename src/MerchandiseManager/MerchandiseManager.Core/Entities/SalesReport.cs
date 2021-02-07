using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;

namespace MerchandiseManager.Core.Entities
{
	public class SalesReport : BaseEntity
	{
		public DateTime Day { get; set; } = DateTime.UtcNow.Date;

		public Store Store { get; private set; }
		public Guid StoreId { get; private set; }

		public ICollection<SoldProduct> SoldProducts { get; set; } = new HashSet<SoldProduct>();

		public SalesReport(Guid storeId)
		{
			StoreId = storeId;
		}
	}
}
