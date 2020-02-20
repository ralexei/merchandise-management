using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Models.ViewModels.Products
{
	public class Product
	{
		public Guid Id { get; set; }

		public string ProductName { get; set; }
		public string ProductDescription { get; set; }

		public decimal? RetailSellPrice { get; set; }
		public decimal? WholesaleSellPrice { get; set; }
		public decimal? BuyPrice { get; set; }

		public Guid? CategoryId { get; set; }

		public List<string> Barcodes { get; set; }

		public int TotalCount { get; set; }
	}
}
