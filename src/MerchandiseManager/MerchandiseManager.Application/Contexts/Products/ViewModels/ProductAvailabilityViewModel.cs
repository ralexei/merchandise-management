using MerchandiseManager.Application.Contexts.Storages.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Products.ViewModels
{
	public class ProductAvailabilityViewModel
	{
		public string ProductName { get; set; }
		public IEnumerable<StorageViewModel> Storages { get; set; }
	}
}
