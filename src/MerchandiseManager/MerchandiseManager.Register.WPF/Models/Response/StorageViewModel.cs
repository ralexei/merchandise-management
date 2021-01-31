using MerchandiseManager.Register.WPF.Models.Common;
using System;

namespace MerchandiseManager.Register.WPF.Models.Response
{
	public class StorageViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public StorageTypes StorageType { get; set; }
	}
}
