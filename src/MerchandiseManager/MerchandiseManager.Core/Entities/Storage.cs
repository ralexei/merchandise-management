using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;

namespace MerchandiseManager.Core.Entities
{
	public partial class Storage : BaseEntity 
	{
		public string StorageName { get; private set; }
		public string StorageDescription { get; private set; }

		public ICollection<StorageProduct> StorageProducts { get; private set; }
	}
}
