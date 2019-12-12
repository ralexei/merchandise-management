using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;

namespace MerchandiseManager.Core.Entities
{
	public class Storage : IBaseEntity, IHasId<Guid>, IHasDate
	{
		public Guid Id { get; private set; }

		public DateTime CreationTime { get; private set; }
		public DateTime? UpdateTime { get; private set; }

		public string WarehouseName { get; private set; }
		public string WarehouseDescription { get; private set; }

		public ICollection<StorageProduct> StorageProducts { get; private set; }
	}
}
