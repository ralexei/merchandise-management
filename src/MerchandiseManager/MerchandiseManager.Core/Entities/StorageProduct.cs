using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class StorageProduct : IBaseEntity, IHasId<Guid>, IHasDate
	{
		public Guid Id { get; private set; }

		public DateTime CreationTime { get; private set; }
		public DateTime? UpdateTime { get; private set; }

		public int ProductsAmount { get; private set; }

		public Product Product { get; private set; }
		public Guid ProductGuid { get; private set; }

		public Storage Storage { get; private set; }
		public Guid StorageGuid { get; private set; }
	}
}
