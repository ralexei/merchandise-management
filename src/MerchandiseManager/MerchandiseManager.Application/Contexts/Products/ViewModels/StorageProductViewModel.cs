using System;

namespace MerchandiseManager.Application.Contexts.Products.ViewModels
{
	public class StorageProductViewModel
	{
		public ProductViewModel Product { get; set; }
		public int ProductsAmount { get; set; }

		public Guid StorageId { get; set; }
	}
}
