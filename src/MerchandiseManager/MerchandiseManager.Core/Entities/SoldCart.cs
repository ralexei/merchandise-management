using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class SoldCart : BaseEntity
	{
		public decimal TotalPrice { get; private set; }
		public decimal ReceivedSum { get; private set; }
		public decimal Change { get; private set; }

		public ICollection<SoldProduct> SoldProducts { get; private set; } = new List<SoldProduct>();

		public static SoldCart SellCartWithProducts(decimal receivedSum, decimal change, IEnumerable<SoldProduct> soldProducts)
		{
			return new SoldCart
			{
				SoldProducts = soldProducts.ToList(),
				ReceivedSum = receivedSum,
				TotalPrice = soldProducts.Sum(s => s.SellPrice),
				Change = change
			};
		}
	}
}
