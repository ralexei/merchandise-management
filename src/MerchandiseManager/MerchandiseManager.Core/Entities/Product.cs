using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class Product : BaseEntity
	{
		public string ProductName { get; private set; }
		public string ProductDescription { get; private set; }

		public decimal? RetailSellPrice { get; private set; }
		public decimal? WholesaleSellPrice { get; private set; }
		public decimal? BuyPrice { get; private set; }

		public int BarcodeFriendlyId { get; set; }

		#region Navigation property
		public Category Category { get; private set; }
		public Guid? CategoryId { get; private set; }

		public User User { get; private set; }
		public Guid UserId { get; private set; }

		public ICollection<StorageProduct> StorageProducts { get; private set; } = new List<StorageProduct>();
		public ICollection<BarCode> BarCodes { get; private set; } = new List<BarCode>();
		#endregion

		public Product AssignToUser(Guid userId)
		{
			UserId = userId;

			return this;
		}
	}
}
