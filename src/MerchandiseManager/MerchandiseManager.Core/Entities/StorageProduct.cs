using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class StorageProduct : BaseEntity 
	{
		public int ProductsAmount { get; private set; }

		public Product Product { get; private set; }
		public Guid ProductId { get; private set; }

		public Storage Storage { get; private set; }
		public Guid StorageId { get; private set; }

		private StorageProduct() { }
		public StorageProduct(Guid productId, int amount, Guid storageId)
		{
			if (amount <= 0)
				throw new ArgumentException($"Wrong amount of products {productId} - {amount}");

			ProductsAmount = amount;
			ProductId = productId;
			StorageId = storageId;
		}

		public void DecreaseQuantityOfGoods(int amount, bool throwOnWrongAmount = false)
		{
			//@TODO-UNHANDLED-EXCEPTION
			if (throwOnWrongAmount && amount > ProductsAmount)
				throw new Exception($"Not enough products. Having: {ProductsAmount}. Trying to sell: {amount}");

			ProductsAmount -= amount;
		}

		public void IncreaseQuantityOfGoods(int amount)
		{
			ProductsAmount += amount;
		}
	}
}
