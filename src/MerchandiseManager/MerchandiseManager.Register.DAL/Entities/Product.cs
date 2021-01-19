using MerchandiseManager.Register.DAL.Entities;
using System.Collections.Generic;

namespace MerchandiseManager.Register.WPF.Persistence.Entities
{
	public class Product : BaseEntity
	{
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }

		public decimal? RetailSellPrice { get; set; }
		public decimal? WholesaleSellPrice { get; set; }
		public decimal? BuyPrice { get; set; }

		public int TotalAmount { get; set; }

		public ICollection<BarCode> BarCodes { get; set; } = new List<BarCode>();
	}
}
