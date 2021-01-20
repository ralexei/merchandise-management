using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Products.ViewModels
{
	public class ProductViewModel
	{
		public Guid Id { get; private set; }
		public string ProductName { get; private set; }
		public string ProductDescription { get; private set; }

		public Guid CategoryId { get; private set; }
		public string CategoryName { get; private set; }

		public decimal RetailSellPrice { get; private set; }
		public decimal? WholesaleSellPrice { get; private set; }
		public decimal? BuyPrice { get; private set; }

		public IEnumerable<BarcodeViewModel> Barcodes { get; private set; }

		public int TotalAmount { get; private set; }
	}
}
