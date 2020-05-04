using MerchandiseManager.Core.Interfaces.Entity;
using System;

namespace MerchandiseManager.Core.Entities
{
	public class UserWarehouse : BaseEntity
	{
		public Guid UserId { get; set; }
		public User User { get; set; }

		public Guid WarehouseId { get; set; }
		public Warehouse Warehouse { get; set; }

		protected UserWarehouse(){}

		public UserWarehouse(Guid userId, Guid warehouseId)
		{
			UserId = userId;
			WarehouseId = warehouseId;
		}

		public UserWarehouse(Guid userId, Warehouse warehouse)
		{
			UserId = userId;
			Warehouse = warehouse;
		}
	}
}
