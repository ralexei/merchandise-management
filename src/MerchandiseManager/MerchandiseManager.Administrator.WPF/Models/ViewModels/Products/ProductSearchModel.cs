using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Models.ViewModels.Products
{
	public class ProductsSearchModel
	{
		public string ProductNameContains { get; set; }
		public decimal? RetailSellPriceMin { get; set; }
		public decimal? RetailSellPriceMax { get; set; }
		public decimal? WholesaleSellPriceMin { get; set; }
		public decimal? WholesaleSellPriceMax { get; set; }
		public decimal? BuyPriceMin { get; set; }
		public decimal? BuyPriceMax { get; set; }
	}
}
