using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class StorageProduct : BaseEntity 
	{
		public int ProductsAmount { get; private set; }

		public Product Product { get; private set; }
		public Guid ProductId { get; private set; }

		public Storage Storage { get; private set; }
		public Guid StorageId { get; private set; }
	}
}
