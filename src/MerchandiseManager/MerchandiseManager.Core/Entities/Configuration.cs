using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public class Configuration
	{
		public Guid Id { get; set; }
		public int LastBarcodeNumber { get; set; }
	}
}
