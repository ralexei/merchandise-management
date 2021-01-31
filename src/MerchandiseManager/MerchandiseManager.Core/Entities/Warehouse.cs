using System;

namespace MerchandiseManager.Core.Entities
{
	public class Warehouse : Storage
	{
		public Guid UserId { get; set; }
		public User User { get; set; }

		protected Warehouse() { }

		public Warehouse(string warehouseName, string warehouseDescription) : base(warehouseName, warehouseDescription) { }

		public Warehouse(string warehouseName) : base(warehouseName) { }
	}
}
