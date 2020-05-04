using MerchandiseManager.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public class Warehouse : Storage
	{
		protected Warehouse() { }

		public Warehouse(string warehouseName, string warehouseDescription) : base(warehouseName) { }

		public Warehouse(string warehouseName) : base(warehouseName) { }
	}
}
