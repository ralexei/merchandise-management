using MerchandiseManager.Register.WPF.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Register.WPF.Models.Common
{
	public class CartProduct
	{
		public Guid ProductId { get; set; }

		public string ProductName { get; set; }

		public decimal RetailSellPrice { get; set; }
		public decimal Sum { get; set; }

		public int Amount { get; set; }

		public CartProduct(Product product)
		{
			ProductId = product.Id;
			ProductName = product.ProductName;
			RetailSellPrice = product.RetailSellPrice.GetValueOrDefault();

			AddToAmount();
		}

		public void AddToAmount()
		{
			Amount++;
			CalculateSum();
		}

		public void DecreaseAmount()
		{
			Amount--;
			CalculateSum();
		}

		private void CalculateSum()
		{
			Sum = Amount * RetailSellPrice;
		}
	}
}
